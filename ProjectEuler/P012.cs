using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // What is the value of the first triangle number to have over five hundred divisors?
    public static class P012
    {
        public static List<int> primes;

        public static int Solve()
        {
            int divisorsCount = 0;

            // we can start from 7th as we know from problem description that it has 6 divisors 
            int i = 7;
            var sieve = Library.SieveOfAtkins(10000000);
            primes = Library.SieveToIntList(sieve);

            while (divisorsCount < 500)
            {
                // sum of adjacent integers can be expressed as Sn = (n * (n + 1)) / 2
                long triangle = (i * (i + 1)) / 2;
                divisorsCount = GetDivisorsCount(triangle);
                Console.WriteLine("Number {0} has {1} divisors", triangle, divisorsCount);
                i++;
            }

            return 0;
        }

        public static int GetDivisorsCount(long n)
        {
            var divisors = new List<long>();
            int product = 1, i = 0;

            while (n > 1)
            {
                int prime = primes[i];

                if (n % prime == 0)
                {
                    divisors.Add(prime);
                    n /= prime;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            var gr = divisors.GroupBy(num => num);
            foreach (var item in gr)
            {
                product *= item.Count() + 1;
            }

            return product;
        }
    }
}
