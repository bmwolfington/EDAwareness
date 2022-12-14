using System;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using EDAwareness.Core.Journal.Events;

namespace EDAwareness.Core.Journal
{
    public class JournalReader : IDisposable
    {
        static FileStreamOptions ReaderOptions = new FileStreamOptions
        {
            Mode = FileMode.Open,
            Access = FileAccess.Read,
            Share = FileShare.ReadWrite,
            Options = FileOptions.Asynchronous | FileOptions.SequentialScan
        };
        static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        static Dictionary<string, Type> JournalEventTypes = GetJournalEventTypeCache();
        static ContinuedEvent? ContinuedFrom;

        TextReader? _reader;

        public string Path => LogFile.Path;
        public JournalLogFile LogFile { get; }

        public JournalReader(string path) : this(new JournalLogFile(path)) { }
        public JournalReader(JournalLogFile logFile)
        {
            LogFile = logFile ?? throw new ArgumentNullException(nameof(logFile));
        }

        public async IAsyncEnumerable<JournalEvent> ReadJournalAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var commanderlessEvents = new Queue<JournalEvent>();
            JournalEvent? journalEvent;

            while ((journalEvent = await ReadJournalEventAsync(cancellationToken)) != null)
            {
                if (journalEvent.EventType == JournalEventType.LoadGame && LogFile.CommanderId == null)
                {
                    commanderlessEvents.Enqueue(journalEvent);
                }
                else
                {
                    foreach (var commanderlessEvent in commanderlessEvents)
                    {
                        commanderlessEvent.CommanderId = LogFile.CommanderId!.Value;

                        yield return commanderlessEvent;
                    }

                    yield return journalEvent;
                }
            }
        }

        public async Task<JournalEvent?> ReadJournalEventAsync(CancellationToken cancellationToken = default)
        {
            var line = await ReadLineAsync(cancellationToken);
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }

            var jsonElement = JsonDocument.Parse(line).RootElement;
            if (!jsonElement.TryGetProperty("event", out var eventName))
            {
                // TODO: Log: JSON was not a well-formed event
                return null;
            }

            if (!JournalEventTypes.TryGetValue(eventName.GetString() ?? string.Empty, out var eventType))
            {
                // TODO: Log: Could not find an event for this event type
                return null;
            }

            JournalEvent? journalEvent;
            try
            {
                journalEvent = JsonSerializer.Deserialize<JournalEvent>(jsonElement, JsonOptions);
            }
            catch (Exception e) 
            {
                // TODO: Log: deserialize error
                Console.Out.WriteLine(e.Message);
                return null;
            }
            if (journalEvent == null)
            {
                // TODO: Log: deserialize error
                return null;
            }

            switch (journalEvent)
            {
                case FileHeaderEvent fileheaderEvent:
                    LogFile.Build = fileheaderEvent.Build;
                    LogFile.GameVersion = fileheaderEvent.GameVersion;

                    if (fileheaderEvent.Part > 1)
                    {
                        // Get commander from previous log if it ends with a Continued event
                        // TODO: Check time?
                        if (ContinuedFrom != null && 
                            ContinuedFrom.Part == fileheaderEvent.Part &&
                            ContinuedFrom.CommanderId.HasValue)
                        {
                            LogFile.CommanderId = ContinuedFrom.CommanderId.Value;
                        }

                        // TODO: Get from database if possible
                    }
                    break;

                case ContinuedEvent continuedEvent:
                    ContinuedFrom = continuedEvent;
                    break;

                case LoadGameEvent loadGameEvent:

            }
        }

        async Task<string?> ReadLineAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _reader ??= new StreamReader(Path, ReaderOptions);

                return await _reader.ReadLineAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _reader?.Close();
                _reader = null;

                // TODO: Log

                return null;
            }
        }

        static Dictionary<string, Type> GetJournalEventTypeCache()
        {
            var journalEventType = typeof(JournalEvent);

            return journalEventType.Assembly.GetTypes()
                .Where(type => type.IsAssignableTo(journalEventType) && !type.IsAbstract)
                .Select(type => new
                {
                    Attribute = type.GetCustomAttribute<JournalEventAttribute>(),
                    Type = type
                })
                .Where(type => type.Attribute != null)
                .ToDictionary(
                    x => x.Attribute!.EventType.ToString(),
                    x => x.Type);
        }

        public void Dispose() => _reader?.Close();
    }
}
