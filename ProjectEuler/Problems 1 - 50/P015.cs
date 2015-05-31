using System.Numerics;

namespace ProjectEuler
{
    // How many routes (moving down or bottom) are there through a 20×20 grid?
    public static class P015
    {
        public static long Solve()
        {
            long result = 1;
            int n = 20, i = 0;

            // in 20x20 there are only paths of lenght 40, which consist of 20 down, 20 right
            // so all the path are actualy a combination of 20 (up, and not up) from 40
            // using multiplicative formula for binomial coefficient (20 from 40): 
            while (++i <= 20)
            {
                result *= (n + i);
                result /= i;
            }

            return result;

            // that's another possible solution but it's way more expensive;
            // equotation can be described as n! / k! * (n - k)!
            // and as n = 2k, it can be further simplified to (2n)! * (n!)^2
            //return Factorial(2 * n) / (Factorial(n) * Factorial(n));
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
    }
}
