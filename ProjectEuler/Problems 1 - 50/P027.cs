using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    // Find the product of the coefficients, a and b, for the quadratic expression that produces 
    // the maximum number of primes for consecutive values of n, starting with n = 0.
    class P027
    {
        public static int Solve()
        {
            var primes = Library.GetPrimes<HashSet<int>>(100000);

            var maxCount = new Tuple<int, int>(0, 0);
            int start = -1000, end = 1000;

            for (int a = start; a < end; a++)
            {
                for (int b = start; b < end; b++)
                {
                    int n = 0, count = 0, fn;

                    do
                    {
                        fn = n * n + a * n + b;
                        count++;
                        n++;
                    }
                    while (primes.Contains(fn));

                    if (count > maxCount.Item1)
                    {
                        maxCount = new Tuple<int, int>(count, a * b);
                    }
                }
            }

            return maxCount.Item2;
        }
    }
}
