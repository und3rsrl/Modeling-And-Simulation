using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Numbers
{
    public class LCG : Generator
    {
        private int _a;
        private int _c;
        private int _m;

        public LCG(int seed, int a, int c, int m)
        {
            Seed = seed;
            _a = a;
            _c = c;
            _m = m;
        }

        public override double Next()
        {
            VerifyIfSeedWasReturnedRecently(Seed);

            Seed = (_a * Seed + _c) % _m;

            return Convert.ToDouble(Seed / (double)_m);
        }
    }
}
