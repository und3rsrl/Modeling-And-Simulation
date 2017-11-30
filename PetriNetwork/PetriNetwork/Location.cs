using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    public class Location
    {
        public Location(string tag, int counters)
        {
            Tag = tag;
            Counters = counters;
        }

        public string Tag
        {
            get;
            set;
        }

        public int Counters
        {
            get;
            set;
        }
    }
}
