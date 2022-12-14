using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAwareness.Core.Journal
{
    public class JournalFileWatcher
    {
        private FileSystemWatcher? _watcher;
        private ConcurrentQueue<string>? _newFileQueue, _changedFileQueue;

        public string Path { get; }
        public string Filter { get; }
        public bool IncludeSubdirectories { get; }

        public JournalFileWatcher(string path, string filter, bool includeSubdirectories)
        {
            Path = path;
            Filter = filter;
            IncludeSubdirectories = includeSubdirectories;
        }

        public void Start()
        {
            try
            {
                _newFileQueue = new ConcurrentQueue<string>();

                _watcher = new FileSystemWatcher
                {
                    Path = Path,
                    Filter = Filter,
                    IncludeSubdirectories = IncludeSubdirectories,
                    EnableRaisingEvents = true,
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
                };
                _watcher.Created += OnCreated;
                _watcher.Changed += OnChanged;

                // TODO: Log
            }
            catch (Exception e)
            {
                // TODO: Log
            }
        }

        public void Stop()
        {
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
                _watcher = null;
            }

            // TODO: Log
        }

        private void OnCreated(object sender, FileSystemEventArgs e) =>
            _newFileQueue?.Enqueue(e.FullPath);

        private void OnChanged(object sender, FileSystemEventArgs e) =>
            _changedFileQueue?.Enqueue(e.FullPath);

    }
}
