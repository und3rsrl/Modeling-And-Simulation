using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    public class CoffeeMachinePetriNet : PetriNetwork
    {
        public CoffeeMachinePetriNet()
        {
            SetupCoffeMachine();
        }

        public void SetupCoffeMachine()
        {
            Location zero = new Location("0", 1);
            Location five = new Location("5", 0);
            Location ten = new Location("10", 0);
            Location fifteen = new Location("15", 0);

            Arrow arrowZeroOutToFive = new Arrow(zero, ArrowDirection.Out, 1);
            Arrow arrowZeroOutToTen = new Arrow(zero, ArrowDirection.Out, 1);
            Arrow arrowZeroInFromC1 = new Arrow(zero, ArrowDirection.In, 1);

            Arrow arrowFiveOutToFifteen = new Arrow(five, ArrowDirection.Out, 1);
            Arrow arrowFiveOutToTen= new Arrow(five, ArrowDirection.Out, 1);
            Arrow arrowFiveInFromZero = new Arrow(five, ArrowDirection.In, 1);

            Arrow arrowTenInFromFive = new Arrow(ten, ArrowDirection.In, 1);
            Arrow arrowTenInFromZero = new Arrow(ten, ArrowDirection.In, 1);
            Arrow arrowTenOutToFifteen = new Arrow(ten, ArrowDirection.Out, 1);

            Arrow arrowFifteenInFromFive = new Arrow(fifteen, ArrowDirection.In, 1);
            Arrow arrowFifteenInFromTen = new Arrow(fifteen, ArrowDirection.In, 1);
            Arrow arrowFifteenOutToZero = new Arrow(fifteen, ArrowDirection.Out, 1);

            Transition transitionFive = new Transition("5");
            transitionFive.Arrows.Add(arrowZeroOutToFive);
            transitionFive.Arrows.Add(arrowFiveInFromZero);
            transitionFive.Arrows.Add(arrowFiveOutToTen);
            transitionFive.Arrows.Add(arrowTenInFromFive);
            transitionFive.Arrows.Add(arrowTenOutToFifteen);
            transitionFive.Arrows.Add(arrowFifteenInFromTen);

            Transition transitionTen = new Transition("10");
            transitionTen.Arrows.Add(arrowZeroOutToTen);
            transitionTen.Arrows.Add(arrowTenInFromZero);
            transitionTen.Arrows.Add(arrowFiveOutToFifteen);
            transitionTen.Arrows.Add(arrowFifteenInFromFive);

            Transition transitionCoffee1 = new Transition("C1");
            transitionCoffee1.Arrows.Add(arrowFifteenOutToZero);
            transitionCoffee1.Arrows.Add(arrowZeroInFromC1);

            Transitions.Add(transitionFive);
            Transitions.Add(transitionTen);
            Transitions.Add(transitionCoffee1);
        }
    }
}
