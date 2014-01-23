using System.Numerics;

namespace ProjectEuler
{
    // Find the sum of the digits in the number 100!
    public static class P020
    {
        public static int Solve()
        {
            int n = 100;
            var factorial = (BigInteger)n;

            while (--n > 1)
            {
                factorial *= n;
            }

            int sum = 0;
            while (factorial != 0)
            {
                sum += (int)(factorial % 10);
                factorial /= 10;
            }

            return sum;
        }
    }
}
