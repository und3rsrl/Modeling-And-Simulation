using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Numbers
{
    public abstract class Generator
    {
        private List<int> _seedCache;

        protected Generator()
        {
            _seedCache = new List<int>();
        }

        public int Seed
        {
            get; set;
        }

        public abstract double Next();

        protected void VerifyIfSeedWasReturnedRecently(int seed)
        {
            if (_seedCache.Exists(x => x == seed))
            {
                _seedCache.Remove(seed);
                Seed += 1;
            }

            if (_seedCache.Count > 100)
                _seedCache.Clear();

            _seedCache.Add(seed);
        }    
    }
}
