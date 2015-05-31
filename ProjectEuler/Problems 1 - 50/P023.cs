using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    public static class P023
    {
        public static int Solve()
        {
            const int limit = 28123;
            var abundants = new List<int>();
            var abundantSums = new HashSet<int>();

            Library.InitiateSieve(limit);

            for (int i = 1; i < limit; i++)
            {
                if (Library.GetProperDivisorsSum(i) > i)
                {
                    abundants.Add(i);
                }
            }

            // generating set of integers that are sum of abdundant numbers
            for (int i = 0; i < abundants.Count - 1; i++)
            {
                for (int j = i; j < abundants.Count; j++)
                {
                    var abdundantSum = abundants[i] + abundants[j];
                    if (abdundantSum > limit)
                    {
                        break;
                    }
                    else
                    {
                        abundantSums.Add(abdundantSum);
                    }
                }
            }

            // if integer is not in the set of abdundantSums, 
            // it cannot be written as a sum of abdudnant numbers
            var nonAbdundantSum = 0;
            for (int i = 1; i < limit; i++)
            {
                if (!abundantSums.Contains(i))
                {
                    nonAbdundantSum += i;
                }
            }

            return nonAbdundantSum;
        }
    }
}
