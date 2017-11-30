using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    public class PetriNetwork
    {
        private List<Transition> _transitions = new List<Transition>();
        private List<Transition> _validTransitions = new List<Transition>();

        public List<Transition> Transitions => _transitions;

        public void Execute(string actiune)
        {
            _validTransitions.Clear();
            foreach (Transition transition in Transitions)
            {   
                if (transition.Tag == actiune && transition.IsValid())
                {
                    _validTransitions.Add(transition);
                }
            }

            foreach (Transition transition in _validTransitions)
            {
                transition.Update();
            }
        }
    }
}
