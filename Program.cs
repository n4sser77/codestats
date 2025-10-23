using codestats;
using codestats.Interfaces;
using codestats.States;
using Codestats.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Codestats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Extract CLI options first
            var options = ParseOptions(args);

            // Determine top-level state
            IAppState state = DetermineState(options);

            var context = new CodestatsContext(state);
            context.Run();
        }

        private static Options ParseOptions(string[] args)
        {
            var options = new Options();

            if (args.Length == 0)
                return options;

            // Determine main command
            string firstArg = args[0].ToLowerInvariant();
            options.CountLines = firstArg is "--countlines" or "cl";
            options.ShowHelp = firstArg == "--help";
            options.ShowVersion = firstArg == "--version";

            // Look for other flags
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i].ToLowerInvariant();

                // --- PATH ---
                if (arg is "--path" or "-p")
                {
                    if (i + 1 < args.Length && !args[i + 1].StartsWith("-"))
                        options.TargetDirectory = args[i + 1];
                }

                // --- TYPES ---
                if (arg is "--types" or "-t")
                {
                    if (i + 1 < args.Length && !args[i + 1].StartsWith("-"))
                    {
                        var extList = args[i + 1]
                            .Split(',')
                            .Select(e => e.Trim().StartsWith(".") ? e.Trim() : "." + e.Trim())
                            .ToList();

                        options.FileTypes = extList;
                    }
                }
            }

            // Default if not set
            if (options.FileTypes == null || !options.FileTypes.Any())
                options.FileTypes = new List<string> { ".cs" };

            if (string.IsNullOrEmpty(options.TargetDirectory))
                options.TargetDirectory = Directory.GetCurrentDirectory();

            return options;
        }


        private static IAppState DetermineState(Options options)
        {
            if (options.ShowHelp) return new HelpState();
            if (options.ShowVersion) return new VersionState();
            if (options.CountLines)
            {
                // inject strategy into CountLinesState
                var strategy = new DefaultCountLinesStrategy(
                    options
                );
                return new CountLinesState(strategy);
            }

            return new HelpState(); // fallback
        }
    }


}
