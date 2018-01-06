using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OfficePostSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Counter> counters = new List<Counter>();

            HashSet<Services> services1 = new HashSet<Services>()
            {
                Services.PayBills,
                Services.PackageDelivery
            };

            Counter counter1 = new Counter(1, services1);

            HashSet<Services> services2 = new HashSet<Services>()
            {
                Services.PayBills,

                Services.PackagePickup
            };

            Counter counter2 = new Counter(2, services2);

            HashSet<Services> services3 = new HashSet<Services>()
            {
                Services.PostalMandate  
            };

            Counter counter3 = new Counter(3, services3);

            counters.Add(counter1);
            counters.Add(counter2);
            counters.Add(counter3);

            Thread thread1 = new Thread(counter1.Serve);
            Thread thread2 = new Thread(counter2.Serve);
            Thread thread3 = new Thread(counter3.Serve);
            

            int count = 0;

            for (int i = 0; i < 12; i++)
            {
                Random random = new Random();
                int persons = random.Next(1, 2);

                while (persons != 0)
                {
                    count++;
                    Person person1= new Person(count.ToString());
                    Thread person = new Thread(() => person1.SearchQueue(counters));
                    person.Start();
                    persons--;
                }
            }

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();


            Console.WriteLine("Numarul clientilor: " + count);
            foreach (var counter in counters)
            {
                Console.WriteLine("Ghiseul" + counter.CounterNumber);
                Console.WriteLine("Timpul mediu asteptare: " + counter.AverageServeTime);
                Console.WriteLine("Marimea maxima a cozii: " + counter.MaxQueueLength);
                Console.WriteLine();
            }

            //thread1.Abort();
            //thread2.Abort();
            //thread3.Abort();
        }
    }
}
