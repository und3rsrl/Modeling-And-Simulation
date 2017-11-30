using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = string.Empty;
            CoffeeMachine coffeeMachine = new CoffeeMachine();


            while (action != "exit")
            {
                Console.WriteLine("These are the actions you can perform:");
                foreach (string state in coffeeMachine.States)
                {
                    Console.WriteLine(state);
                }
                Console.WriteLine("In order to exit, enter: exit");

                Console.WriteLine("Enter your option:");
                action = Console.ReadLine();
                Console.WriteLine();

                if(action != "exit")
                    coffeeMachine.Execute(action);
            }

        }
    }
}
