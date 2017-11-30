using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    public class Arrow
    {
        public Arrow(Location location, ArrowDirection direction, int capacity)
        {
            Location = location;
            Direction = direction;
            Capacity = capacity;
        }

        public int Capacity
        {
            get;
            set;
        }

        public Location Location
        {
            get;
            set;
        }

        public ArrowDirection Direction
        {
            get;
            set;
        }

        public bool IsValid()
        {
            if ((Capacity >= Location.Counters && Direction == ArrowDirection.Out) || Direction == ArrowDirection.In)
                return true;

            return false;
        }

        public void Update()
        {
            if (Direction == ArrowDirection.In)
                Location.Counters += Capacity;
            else
                Location.Counters -= Capacity;
        }

        public void printMessage()
        {
            if (Direction == ArrowDirection.In && Location.Tag == "0")
                Console.WriteLine("Cafeaua este gata.");
        }
    }
}
