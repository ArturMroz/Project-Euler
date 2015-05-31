using System;

namespace ProjectEuler
{
    // Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    class P030
    {
        public static int Solve()
        {
            var powers = new int[10];

            // generating powers cache
            for (int i = 0; i < 10; i++)
            {
                powers[i] = (int)Math.Pow(i, 5);
            }

            // 9^5 * 7 = 413343, so we can set a limit
            int limit = 413343;
            int totalSum = 0;

            for (int i = 10; i < limit; i++)
            {
                int n = i, sum = 0;

                while (n != 0)
                {
                    int t = n % 10;
                    n /= 10;
                    sum += powers[t];
                }

                if (sum == i)
                {
                    totalSum += i;
                }
            }

            return totalSum;
        }
    }
}
