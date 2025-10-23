using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codestats
{
    internal class Options
    {
        public bool ShowHelp { get; set; }
        public bool ShowVersion { get; set; }
        public bool CountLines { get; set; }

        // Options for CountLines
        public string TargetDirectory { get; set; } = Directory.GetCurrentDirectory();
        public List<string> FileTypes { get; set; } = new() { ".cs" };
        public List<string> ExcludeFolders { get; set; } = new() { "bin", "obj", ".git", "node_modules" };
    }

}
