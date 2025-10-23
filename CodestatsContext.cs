using codestats.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codestats
{
    internal class CodestatsContext
    {
        private IAppState _state;

        public CodestatsContext(IAppState state)
        {
            _state = state;
        }

        public void SetState(IAppState state)
        {
            _state = state;
        }

        public void Run()
        {
            _state.Execute();
        }
    }
}
