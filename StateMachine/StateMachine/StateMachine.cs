using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public abstract class StateMachine
    {
        private readonly Dictionary<string, Dictionary<string, string>> _states = new Dictionary<string, Dictionary<string, string>>();

        public string CurrentState
        {
            get;
            set;
        }

        public Dictionary<string, Dictionary<string, string>> TableOfAction => _states;

        public abstract void Execute(string action);
    }
}
