using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Numbers
{
    public class MidSquare : Generator
    {
        private int _seedNumberOfDigits;
        
        public MidSquare(int seed)
        {
            Seed = seed;
            _seedNumberOfDigits = Seed.ToString().Length;
        }

        public override double Next()
        {
            VerifyIfSeedWasReturnedRecently(Seed);
            VerifyIfForValidSeed(Seed);

            Seed = (int)Math.Pow(Seed, 2);
            Seed = ExtractSeed();

            return Convert.ToDouble(Seed / Math.Pow(10, _seedNumberOfDigits));
        }

        private int ExtractSeed()
        {
            return (Seed / (int)Math.Pow(10, _seedNumberOfDigits / 2)) % (int)Math.Pow(10, _seedNumberOfDigits);
        }

        private void VerifyIfForValidSeed(int seed)
        {
            int currentNumberOfDigits = seed.ToString().Length;

            if (currentNumberOfDigits < _seedNumberOfDigits)
            {
                int correctingSteps = _seedNumberOfDigits - currentNumberOfDigits;

                while (correctingSteps != 0)
                {
                    Seed = Seed * 10 + 1;
                    correctingSteps--;
                }
            }
        }
    }
}
