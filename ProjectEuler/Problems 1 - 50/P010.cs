﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // Find the sum of all the primes below two million.
    public static class P010
    {
        public static long Solve()
        {
            int limit = 2000000;
            return SieveOfAtkins(limit);
        }

        public static long SieveOfAtkins(int limit)
        {
            int sqrtLimit, x, y, z, i;
            var sieve = new bool[limit + 1];
            sieve[2] = sieve[3] = true;

            // set search limit for primes
            sqrtLimit = (int)(Math.Sqrt(limit));

            for (x = 1; x <= sqrtLimit; x++)
            {
                for (y = 1; y <= sqrtLimit; y++)
                {
                    // flip the entry for each possible solution to z
                    // where rest from division equals 1 or 5
                    z = 4 * x * x + y * y;
                    if ((z <= limit) && ((z % 12 == 1) || (z % 12 == 5)))
                    {
                        sieve[z] = !sieve[z];
                    }

                    // flip the entry for each possible solution to z
                    // where rest from division equals 7
                    z -= x * x;
                    if ((z <= limit) && (z % 12 == 7))
                    {
                        sieve[z] = !sieve[z];
                    }

                    // flip the entry for each possible solution to z
                    // where rest from division equals 11 and x > y
                    if (x > y)
                    {
                        z -= 2 * y * y;
                        if ((z <= limit) && (z % 12 == 11))
                        {
                            sieve[z] = !sieve[z];
                        }
                    }
                }
            }

            // eliminate composites by sieving
            for (int n = 5; n <= sqrtLimit; n++)
            {
                if (sieve[n])
                {
                    // n is prime, omit multiples of its square
                    x = n * n;
                    for (i = x; i <= limit; i += x)
                    {
                        sieve[i] = false;
                    }
                }
            }

            return SumOfPrimes(sieve);
        }

        public static long SumOfPrimes(bool[] sieve)
        {
            long sum = 0;
            for (int i = 2; i < sieve.Count(); i++)
            {
                if (sieve[i])
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
