using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class P035
    {
        public static int Solve()
        {
            int limit = 1000000, count = 0;
            var primes = Library.GetPrimes<HashSet<int>>(limit);
            bool areAllPrimes;

            foreach (int prime in primes)
            {
                areAllPrimes = true;
                
                var rotations = GetRotations(NumberToList(prime));
                foreach (var item in rotations)
                {
                    if (!primes.Contains(item))
                    {
                        areAllPrimes = false;
                        break;
                    }
                }

                if (areAllPrimes) count++;
            }

            return count;
        }

        public static List<int> GetRotations(List<int> list)
        {
            var temp = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                list.MoveLastItemToFront();
                temp.Add(ListToNumber(list));
            }

            return temp;
        }

        public static void MoveLastItemToFront<T>(this List<T> list)
        {
            T item = list[0];
            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i] = list[i + 1];
            }

            list[list.Count - 1] = item;
        }

        public static int ListToNumber(List<int> list)
        {
            int n = 0, i = 1;
            foreach (var item in list)
            {
                n += item * i;
                i *= 10;
            }

            return n;
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
    }
}
