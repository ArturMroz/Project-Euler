using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // What is the value of the first triangle number to have over five hundred divisors?
    public static class P012
    {
        public static List<int> primes;

        public static long Solve()
        {
            int divisorsCount = 0;
            long triangle = 0;

            // we can start from 7th as we know from problem description that it has 6 divisors 
            int i = 7;
            var sieve = Library.SieveOfAtkins(100000);
            primes = Library.SieveToIntList(sieve);

            while (divisorsCount < 500)
            {
                // sum of adjacent integers can be expressed as Sn = (n * (n + 1)) / 2
                triangle = (i * (i + 1)) / 2;
                divisorsCount = GetDivisorsCount(triangle);
                i++;
            }

            return triangle;
        }

        public static int GetDivisorsCount(long n)
        {
            var primeFactors = new List<long>();
            int divisorsCount = 1, i = 0;

            // get prime factors of number
            // n = (p1^r1) * (p2^r2 ) *... * (ps^rs)...
            while (n > 1)
            {
                int prime = primes[i];

                if (n % prime == 0)
                {
                    primeFactors.Add(prime);
                    n /= prime;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            // ...and divisor can be described as d = p1^t1 * p2^t2 * ... * ps^ts 
            // therefore, number of divisors is (r1 + 1) * (r2 + 1) * ... * ( rs + 1 )
            var factorsGroupedByValue = primeFactors.GroupBy(num => num);
            foreach (var item in factorsGroupedByValue)
            {
                // group count is power of factor
                divisorsCount *= item.Count() + 1;
            }

            return divisorsCount;
        }
    }
}
