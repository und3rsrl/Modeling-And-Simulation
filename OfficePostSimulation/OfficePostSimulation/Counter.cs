using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePostSimulation
{
    public class Counter : ICounter
    {
        private const int min_serve_time = 100;
        private const int max_serve_time = 500;
        private int _maxQueueLength;

        private HashSet<Services> _services;
        private int _counterNumber;
        private BlockingCollection<Person> _personsQueue;
        private System.Object lockThis = new System.Object();

        private int _servedPersons;
        private int _totalTimeSpent;

        public Counter(int counterNumber, HashSet<Services> serviceses)
        {
            _counterNumber = counterNumber;
            _services = serviceses;
            _personsQueue = new BlockingCollection<Person>();
            _servedPersons = 0;
        }

        public HashSet<Services> Services => _services;

        public int AverageServeTime => CalculateAverageServeTime();

        public int MaxQueueLength => _maxQueueLength;

        public int PersonsWaiting => _personsQueue.Count;

        public int CounterNumber => _counterNumber;

        public void AddToQueue(Person person)
        {

            Console.WriteLine(person.Name + " s-a asezat la coada ghiseului " + _counterNumber);
            _personsQueue.Add(person);

            if (_maxQueueLength < _personsQueue.Count)
                _maxQueueLength = _personsQueue.Count;

        }

        public void Serve()
        {

            while (_personsQueue.Count != 0)
            {
                Person person = _personsQueue.Take();

                Console.WriteLine(person.Name + " este servit la ghiseul: " + _counterNumber);

                Random random = new Random();


                int serveTime = 0;
                int personServeTime = 0;
                foreach (var Service in person.Services)
                {
                    serveTime = random.Next(min_serve_time, max_serve_time);
                    Thread.Sleep(serveTime);
                    personServeTime += serveTime;
                    Console.WriteLine(Service.ToString());
                }

                _totalTimeSpent += personServeTime;

                Console.WriteLine(person.Name + " a fost servit la ghiseul " + _counterNumber);
                person.InQueue = false;
                _servedPersons++;

            }
        }

        private int CalculateAverageServeTime()
        {
            if (_servedPersons == 0)
                return 0;

            return _totalTimeSpent / _servedPersons;
        }
    }
}
