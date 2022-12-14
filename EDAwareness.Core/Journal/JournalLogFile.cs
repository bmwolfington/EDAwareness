using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace EDAwareness.Core.Journal
{
    public class JournalLogFile
    {
        public int? CommanderId { get; set; }
        public string? Build { get; set; }
        public string? GameVersion { get; set; }

        public string Path { get; }
        //public string FileName { get; }
        //public string DirectoryName { get; }

        public JournalLogFile(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The journal log unit file does not exist", path);
            }

            //FileName = System.IO.Path.GetFileName(Path);
            //DirectoryName = System.IO.Path.GetDirectoryName(Path)!;
        }
    }
}
