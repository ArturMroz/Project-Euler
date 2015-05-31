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
            return SieveOfAtkins(limit);
        }

        // Sieve of Atkins algorithm, faster than Eratosthenes'
        public static int SieveOfAtkins(int limit)
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

            return GetNthPrimeFromSieve(sieve, 10001);
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
