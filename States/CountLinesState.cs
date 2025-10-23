using codestats.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codestats.States
{
    internal class CountLinesState : IAppState
    {
        private readonly ICountLinesStrategy _strategy;

        public CountLinesState(ICountLinesStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Execute()
        {
            _strategy.Execute();
        }

        

    }
}
