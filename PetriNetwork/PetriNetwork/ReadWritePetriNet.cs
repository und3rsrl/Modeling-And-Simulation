using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNetwork
{
    public class ReadWritePetriNet : PetriNetwork
    {
        public ReadWritePetriNet()
        {
            SetupReadWritePetriNet();
        }

        public void SetupReadWritePetriNet()
        {
            Location workers = new Location("workers", 3);
            Location reading = new Location("reading", 0);
            Location writing = new Location("Writing", 0);

            Arrow arrowWorkersOutToReading = new Arrow(workers, ArrowDirection.Out, 3);
            Arrow arrowWorkersInFromReading = new Arrow(workers, ArrowDirection.In, 3);

            Arrow arrowReadingInFromWorkers = new Arrow(reading, ArrowDirection.In, 3);
            Arrow arrowReadingOutToWorkers = new Arrow(reading, ArrowDirection.Out, 3);

            Arrow arrowWorkersOutToWriting = new Arrow(workers, ArrowDirection.Out, 3);
            Arrow arrowWorkersInFromWriting = new Arrow(workers, ArrowDirection.In, 3);

            Arrow arrowWritingInFromWorkers = new Arrow(reading, ArrowDirection.In, 3);
            Arrow arrowWritingOutToWorkers = new Arrow(reading, ArrowDirection.Out, 3);

            Transition startRead = new Transition("StartRead");
            startRead.Arrows.Add(arrowWorkersOutToReading);
            startRead.Arrows.Add(arrowReadingInFromWorkers);

            Transition endRead = new Transition("EndRead");
            endRead.Arrows.Add(arrowReadingOutToWorkers);
            endRead.Arrows.Add(arrowWorkersInFromReading);

            Transition startWrite = new Transition("StartWrite");
            startWrite.Arrows.Add(arrowWorkersOutToWriting);
            startWrite.Arrows.Add(arrowWritingInFromWorkers);

            Transition endWrite = new Transition("EndWrite");
            endWrite.Arrows.Add(arrowWritingOutToWorkers);
            endWrite.Arrows.Add(arrowWorkersInFromWriting);

            Transitions.Add(startRead);
            Transitions.Add(endRead);
            Transitions.Add(startWrite);
            Transitions.Add(endWrite);
        }
    }
}
