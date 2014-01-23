using System.Numerics;

namespace ProjectEuler
{
    // What is the sum of the digits of the number 2^1000?
    public static class P016
    {
        public static int Solve()
        {
            var n = (BigInteger)1 << 1000;

            int sum = 0;
            while (n != 0)
            {
                sum += (int)(n % 10);
                n /= 10;
            }

            return sum;
        }
    }
}
