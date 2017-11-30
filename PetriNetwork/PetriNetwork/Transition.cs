using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    public class Transition
    {
        private List<Arrow> _arrows = new List<Arrow>();
        private List<Arrow> _validArrows = new List<Arrow>();

        public Transition(string tag)
        {
            Tag = tag;
        }

        public string Tag
        {
            get;
            set;
        }

        public List<Arrow> Arrows => _arrows;

        public bool IsValid()
        {
            _validArrows.Clear();

            foreach (Arrow arrow in Arrows)
            {   
                if (arrow.IsValid())
                    _validArrows.Add(arrow);    
            }

            if (_validArrows.Count > 0)
                return true;

            return false;
        }

        public void Update()
        {
            foreach (Arrow arrow in _validArrows)
            {
                arrow.Update();
                arrow.printMessage();
            }
        }
    }
}
