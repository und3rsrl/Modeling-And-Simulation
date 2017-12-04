using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            //PetriNetwork petriNetwork = new CoffeeMachinePetriNet();
            //PetriNetwork petriNetwork = new ReadWritePetriNet();
            PetriNetwork petriNetwork = new ProduceConsumePetriNet();

            string action = string.Empty;
            while (action != "quit")
            {
                action = Console.ReadLine();
                petriNetwork.Execute(action);
            }
        }
    }
}
