using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new LCG(19, 22, 4, 63);
            //Generator generator = new MidSquare(5197);


            for (int i = 0; i < 67; i++)
            {
     
                Console.WriteLine(i + ". " + generator.Next());
            }
        }
    }
}
