using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    // Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000
    class P048
    {
        public static long Solve()
        {
            BigInteger sum = 0;
            var lastDigits = new List<int>();

            for (int i = 1; i <= 1000; i++)
            {
                sum += BigInteger.Pow(i, i);
            }

            for (int i = 0; i < 10; i++)
            {
                lastDigits.Add((int)(sum % 10));
                sum /= 10;
            }

            return Library.ListToNumber(lastDigits);
        }
    }
}
