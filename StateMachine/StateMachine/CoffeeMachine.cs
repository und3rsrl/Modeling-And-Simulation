using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public class CoffeeMachine : StateMachine
    {
        private readonly List<string> actions;

        public CoffeeMachine()
        {
            CurrentState = "0";
            actions = new List<string>
            {
                "5 lei",
                "10 lei",
                "15 lei",
                "C1 (15 lei)",
                "C2 (10 lei)"
            };
            SetupTable();
        }



        public List<string> States => actions;

        public override void Execute(string action)
        {
            bool ok = TableOfAction.TryGetValue(CurrentState, out Dictionary<string, string>  choices);

            if (ok)
            {
                ok = choices.TryGetValue(action, out string nextState);

                if (ok)
                {
                    CurrentState = nextState;
                    Console.WriteLine("The next current state is: " + CurrentState + "\n");
                }
                else
                    Console.WriteLine("You don't have enought money to perform the " + action + " action. \n");
            }
            else
                Console.WriteLine("The current state is not valid: " + CurrentState);
        }

        private void SetupTable()
        {            
            Dictionary<string, string> actionsForZero = new Dictionary<string, string>();
            actionsForZero.Add("5", "5");
            actionsForZero.Add("10", "10");

            Dictionary<string, string> actionsForFive = new Dictionary<string, string>();
            actionsForFive.Add("5", "10");
            actionsForFive.Add("10", "15");

            Dictionary<string, string> actionsForTen = new Dictionary<string, string>();
            actionsForTen.Add("5", "15");
            actionsForTen.Add("C2", "0");

            Dictionary<string, string> actionsForFifteen = new Dictionary<string, string>();
            actionsForFifteen.Add("C1", "0");
            actionsForFifteen.Add("C2", "5");

            TableOfAction.Add("0", actionsForZero);
            TableOfAction.Add("5", actionsForFive);
            TableOfAction.Add("10", actionsForTen);
            TableOfAction.Add("15", actionsForFifteen);
        }
    }
}
