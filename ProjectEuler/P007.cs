using System;

namespace ProjectEuler
{
    // What is the 10 001st prime number?
    public static class P007
    {
        private static int limit = 200000;
        private const int N = 10001;

        public static int Solve()
        {
            return SieveOfAtkins();
        }

        public static int SieveOfEratosthenes()
        {
            bool[] sieve = new bool[limit];

            // set all values to true
            for (int i = 2; i < limit; i++)
            {
                sieve[i] = true;
            }

            for (int j = 2; j < limit; j++)
            {
                if (sieve[j])
                {
                    // if number is prime, mark all its multiples
                    for (long p = 2; (p * j) < limit; p++)
                    {
                        sieve[p * j] = false;
                    }
                }
            }

            return GetNthPrimeFromSieve(sieve);
        }

        // Sieve of Atkins algorithm, faster than Eratosthenes'
        public static int SieveOfAtkins()
        {
            bool[] sieve = new bool[limit + 1];
            int limitSqrt = (int)System.Math.Sqrt((double)limit);

            sieve[2] = sieve[3] = true;

            // loop through all possible integer values for x and y
            // up to the square root of the max prime for the sieve
            // we don't need any larger values for x or y since the
            // max value for x or y will be the square root of n
            // in the quadratics
            // the theorem showed that the quadratics will produce all
            // primes that also satisfy their wheel factorizations, so
            // we can produce the value of n from the quadratic first
            // and then filter n through the wheel quadratic 
            // loop through all integers for x and y for calculating
            // the quadratics
            for (int x = 1; x <= limitSqrt; x++)
            {
                for (int y = 1; y <= limitSqrt; y++)
                {
                    // first quadratic using m = 12 and r in R1 = {r : 1, 5}
                    int n = (4 * x * x) + (y * y);
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                    {
                        sieve[n] = !sieve[n];
                    }

                    // second quadratic using m = 12 and r in R2 = {r : 7}
                    n = (3 * x * x) + (y * y);
                    if (n <= limit && (n % 12 == 7))
                    {
                        sieve[n] = !sieve[n];
                    }

                    // third quadratic using m = 12 and r in R3 = {r : 11}
                    n = (3 * x * x) - (y * y);
                    if (x > y && n <= limit && (n % 12 == 11))
                    {
                        sieve[n] = !sieve[n];
                    }
                    // note that R1 union R2 union R3 is the set R
                    // R = {r : 1, 5, 7, 11}
                    // which is all values 0 < r < 12 where r is 
                    // a relative prime of 12
                    // Thus all primes become candidates
                } 
            }

            // remove all perfect squares since the quadratic
            // wheel factorization filter removes only some of them
            for (int n = 5; n <= limitSqrt; n++)
            {
                if (sieve[n])
                {
                    int x = n * n;
                    for (int i = x; i <= limit; i += x)
                    {
                        sieve[i] = false;
                    }
                }
            }

            return GetNthPrimeFromSieve(sieve);
        }

        public static int GetNthPrimeFromSieve(bool[] sieve, int n = N)
        {
            int count = 0, index = 1;
            while (count < n)
            {
                if (sieve[++index])
                {
                    count++;
                }
            };

            return index;
        }

        public static int BruteForce()
        {
            int count = 0, index = 1;
            while (count < 10001)
            {
                if (IsPrime(++index))
                {
                    count++;
                }
            };

            return index;
        }

        public static bool IsPrime(long n)
        {
            if (n < 2)
            {
                return false;
            }

            // 2 and 3 are primes...
            for (long i = 2; i < n - 1; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
