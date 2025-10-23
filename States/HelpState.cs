using codestats.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codestats.States
{
    internal class HelpState : IAppState
    {
        public void Execute()
        {
            PrintHelp();
        }

        static void PrintHelp()
        {
            Console.WriteLine("Usage: codestats [options]");
            Console.WriteLine("Usage: codestats [target-directory] [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --version      Show version information");
            Console.WriteLine("  --help         Show help information");
            Console.WriteLine("  --countlines | cl   Count lines in the current directory");


        }


    }
}
