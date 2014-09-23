using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    // Library of the commonly used methods across the project.
    public static class Library
    {
        private static List<int> primes;
        const int LIMIT = 10000000;

        public static string Solve()
        {
            int[] items = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int count = 1, limit = 1000000;

            // Dijkstra algorithm for lexicographic order permutation
            while (count < limit)
            {
                int n = items.Length, i = n - 1;

                while (items[i - 1] >= items[i])
                {
                    i--;
                }

                int j = n;
                while (items[j - 1] <= items[i - 1])
                {
                    j--;
                }

                Swap(items, (i++) - 1, j - 1);

                j = n;

                while (i < j)
                {
                    Swap(items, (i++) - 1, (j--) - 1);
                }

                count++;
            }

            // int[] to string
            return items.Aggregate(string.Empty, (s, i) => s + i.ToString());
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        public static BigInteger Factorial(long n)
        {
            BigInteger result = n;
            while (--n > 1)
            {
                result *= n;
            }

            return result;
        }

        public static void InitiateSieve(int limit)
        {
            //var sieve = Library.SieveOfAtkins();
            primes = GetPrimesList(limit);
        }

        public static bool[] SieveOfAtkins(int limit)
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

            return sieve;
        }

        public static List<int> GetPrimesList(int limit)
        {
            var list = new List<int> { };
            var sieve = SieveOfAtkins(limit);

            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    list.Add(i);
                }
            }

            return list;
        }

        public static HashSet<int> GetPrimesSet(int limit)
        {
            var hashSet = new HashSet<int> { };
            var sieve = SieveOfAtkins(limit);

            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    hashSet.Add(i);
                }
            }

            return hashSet;
        }

        public static T GetPrimes<T>(int limit) where T : ICollection<int>, new()
        {
            var collection = new T();
            var sieve = SieveOfAtkins(limit);

            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    collection.Add(i);
                }
            }

            return collection;
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

        public static List<int> GetPrimeFactors(long n)
        {
            if (primes == null)
            {
                Library.InitiateSieve(LIMIT);
            }

            var primeFactors = new List<int>();
            int i = 0;

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

            return primeFactors;
        }

        public static int GetDivisorsCount(List<int> primeFactors)
        {
            int divisorsCount = 1;
            var factorsGroupedByValue = primeFactors.GroupBy(num => num);

            foreach (var item in factorsGroupedByValue)
            {
                divisorsCount *= item.Count() + 1;
            }

            return divisorsCount;
        }

        public static long GetProperDivisorsSum(long n)
        {
            var primeFactors = GetPrimeFactors(n);
            return GetDivisorsSum(primeFactors) - n;
        }

        public static List<long> GetAllDivisors(int number)
        {
            var primeFactors = GetPrimeFactors(number);
            var factorsGroupedByValue = primeFactors.GroupBy(n => n).ToList();
            int count = 1;
            var divisors = new List<long> { 1 };

            for (int i = 0; i < factorsGroupedByValue.Count(); i++)
            {
                var current = factorsGroupedByValue[i];
                int p = current.Key, e = current.Count();

                int n = count;
                for (int j = 0; j < e; j++)
                {
                    for (int a = 0; a < n; a++)
                    {
                        divisors.Add(p * divisors[a + j * n]);
                        count++;
                    }
                }
            }
            
            return divisors;
        }

        public static long GetDivisorsSum(List<int> primeFactors)
        {
            long sum = 1, subSum;
            var factorsGroupedByValue = primeFactors.GroupBy(num => num);

            foreach (var item in factorsGroupedByValue)
            {
                subSum = 0;
                if (item.Count() > 1)
                {
                    for (int i = item.Count(); i > 0; i--)
                    {
                        subSum += (long)Math.Pow(item.Key, i);
                    }
                }
                else
                {
                    subSum = item.Key;
                }

                sum *= subSum + 1;
            }

            return sum;
        }

        public static List<int> NumberToList(int n)
        {
            var list = new List<int>();
            while (n != 0)
            {
                list.Add(n % 10);
                n /= 10;
            }

            return list;
        }

        public static long ListToNumber(List<int> list)
        {
            long n = 0, i = 1;
            foreach (var item in list)
            {
                n += item * i;
                i *= 10;
            }

            return n;
        }
    }
}
