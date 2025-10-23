using codestats;
using codestats.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Codestats.Strategies
{
    internal class DefaultCountLinesStrategy : ICountLinesStrategy
    {
        private readonly string _directory;
        private List<string> _fileTypes = [".cs"];
        private readonly List<string> _excludeFolders;
        private List<string> ignored = ["bin", "obj", ".git", "node_modules"];

        public DefaultCountLinesStrategy(Options ops)
        {
            _directory = ops.TargetDirectory ?? Directory.GetCurrentDirectory();
            if (ops.FileTypes.Any())
            {
                _fileTypes = ops.FileTypes;
            }
            if (ops.ExcludeFolders.Any())
            {

                ops.ExcludeFolders.AddRange(ignored);
            }
            _excludeFolders = ops.ExcludeFolders;
        }

        public void Execute()
        {
            var files = Directory.GetFiles(_directory, "*.*", SearchOption.AllDirectories)
                .Where(file =>
                    _fileTypes.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)) &&
                    !_excludeFolders.Any(ex => file.Contains(ex)))
                .ToList();

            var lineCountPerType = new Dictionary<string, int>();
            int totalLines = 0;

            foreach (var file in files)
            {
                try
                {
                    int lines = File.ReadLines(file).Count(); // stream, memory-efficient
                    totalLines += lines;

                    var ext = Path.GetExtension(file);
                    if (!lineCountPerType.ContainsKey(ext))
                        lineCountPerType[ext] = 0;
                    lineCountPerType[ext] += lines;
                }
                catch
                {
                    // skip unreadable files
                }
            }

            // Output results
            Console.WriteLine("\n📊 Line Count Summary");
            Console.WriteLine(new string('-', 30));
            foreach (var kv in lineCountPerType)
                Console.WriteLine($"{kv.Key,-10}: {kv.Value,8:N0} lines");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"TOTAL        : {totalLines,8:N0} lines");
        }
    }
}
