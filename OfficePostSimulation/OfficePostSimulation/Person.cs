using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePostSimulation
{
    public class Person
    {
        private int _waitingTime;
        private HashSet<Services> _neededServices = new HashSet<Services>();
        
        public Person(string name)
        {
            Name = name;
            _waitingTime = 0;

            Random random = new Random();
            int numberOfServicesNeeded = random.Next(1, 3);

            while (numberOfServicesNeeded != 0)
            {
                Services service = (Services)(random.Next(0, 99999) % 4);

                while(_neededServices.Contains(service))
                    service = (Services)(random.Next(0, 99999) % 4);

                _neededServices.Add(service);
                numberOfServicesNeeded--;
            }

            InQueue = false;
        }

        public bool InQueue;

        public String Name;

        public HashSet<Services> Services;

        public void SearchQueue(List<Counter> counters)
        {
            while (_neededServices.Count != 0)
            {
                if (InQueue == false)
                {
                    Counter chosenCounter = counters[0];

                    for (int i = 1; i < counters.Count; i++)
                    {
                        Services = HasNeededService(counters[i]);

                        if (counters[i].PersonsWaiting >= chosenCounter.PersonsWaiting && Services.Count > 0)
                            chosenCounter = counters[i];
                    }

                    chosenCounter.AddToQueue(this);

                    InQueue = true;

                    foreach (var service in Services)
                    {
                        _neededServices.Remove(service);
                    }
                }
            }
        }

        private HashSet<Services> HasNeededService(Counter counter)
        {
            HashSet<Services> services = new HashSet<Services>();

            foreach (var service in _neededServices)
            {
                if (counter.Services.Contains(service))
                    services.Add(service);
            }

            return services;
        }
    }
}
