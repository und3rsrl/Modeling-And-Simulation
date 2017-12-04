using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    public class ProduceConsumePetriNet : PetriNetwork
    {
        public ProduceConsumePetriNet()
        {
            SetupProduceConsumePetriNet();
        }

        public void SetupProduceConsumePetriNet()
        {
            Location producers = new Location("Producers", 3);
            Location consumers = new Location("Consumers", 2);
            Location elementProduced = new Location("ElementReadyWrite", 0);
            Location elementConsumed = new Location("ElementReadyRead", 0);
            Location freeSpots = new Location("FreeSpots", 5);
            Location fullSpots = new Location("FullSpots", 0);
            Location mutex = new Location("Mutex", 1);

            Arrow producersOutToElemReady = new Arrow(producers, ArrowDirection.Out, 3);
            Arrow producersInFromElemReady = new Arrow(producers, ArrowDirection.In, 1);

            Arrow elemReadyInFromProducers = new Arrow(elementProduced, ArrowDirection.In, 3);
            Arrow elemReadyOutToProducers = new Arrow(elementProduced, ArrowDirection.Out, 1);

            Arrow fullSpotsInFromFreeSpots = new Arrow(fullSpots, ArrowDirection.In, 1);
            Arrow fullSpotsOutToFreeSpots = new Arrow(fullSpots, ArrowDirection.Out, 1);

            Arrow freeSpotsInFromFullSpots = new Arrow(freeSpots, ArrowDirection.In, 1);
            Arrow freeSpotsOutToFullSpots = new Arrow(freeSpots, ArrowDirection.Out, 1);

            Arrow mutexInFromMutex = new Arrow(mutex, ArrowDirection.In, 1);
            Arrow mutexsOutToMutex = new Arrow(mutex, ArrowDirection.Out, 1);

            Arrow elementConsumeInFromQueue = new Arrow(elementConsumed, ArrowDirection.In, 1);
            Arrow elemConsumeOutToConsumers = new Arrow(elementConsumed, ArrowDirection.Out, 1);

            Arrow consumersInFromElemCons = new Arrow(consumers, ArrowDirection.In, 1);
            Arrow consumersOutToPush = new Arrow(consumers, ArrowDirection.Out, 3);

            Transition produce = new Transition("Produce");
            produce.Arrows.Add(producersOutToElemReady);
            produce.Arrows.Add(elemReadyInFromProducers);

            Transition push = new Transition("Push");
            push.Arrows.Add(elemReadyOutToProducers);
            push.Arrows.Add(producersInFromElemReady);
            push.Arrows.Add(fullSpotsInFromFreeSpots);
            push.Arrows.Add(freeSpotsOutToFullSpots);
            push.Arrows.Add(mutexInFromMutex);
            push.Arrows.Add(mutexsOutToMutex);

            Transition pop = new Transition("Pop");
            pop.Arrows.Add(consumersOutToPush);
            pop.Arrows.Add(elementConsumeInFromQueue);
            pop.Arrows.Add(freeSpotsInFromFullSpots);
            pop.Arrows.Add(fullSpotsOutToFreeSpots);
            pop.Arrows.Add(mutexInFromMutex);
            pop.Arrows.Add(mutexsOutToMutex);

            Transition consume = new Transition("Consume");
            pop.Arrows.Add(elemConsumeOutToConsumers);
            pop.Arrows.Add(consumersInFromElemCons);

            Transitions.Add(produce);
            Transitions.Add(push);
            Transitions.Add(pop);
            Transitions.Add(consume);
        }
    }
}
