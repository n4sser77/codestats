using codestats.Interfaces;
using System;
using System.Reflection; // You need this namespace

namespace codestats.States
{
    internal class VersionState : IAppState // Assuming IAppState is in codestats.Interfaces
    {
        public void Execute()
        {
            // Use Assembly.GetEntryAssembly() to get the assembly that started the process (the CLI executable).
            // Then, use GetCustomAttribute<AssemblyInformationalVersionAttribute>() to retrieve the version string.
            // This is the recommended way to get the display version for the end-user.

            string v = Assembly.GetEntryAssembly()?
                              .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                              .InformationalVersion ?? "Unknown";

            Console.WriteLine($"codestats version {v}");
        }
    }
}