namespace ProjectEuler
{
    // What is the largest prime factor of the number 600851475143 ?
    public static class P003
    {
        public static long Solve()
        {
            long number = 600851475143;
            int factor = 2, primeFactor = 2;

            while (number > 1)
            {
                if (number % factor == 0)
                {
                    if (IsPrime(factor))
                    {
                        primeFactor = factor;
                    }

                    number /= factor;
                }
                else
                {
                    factor++;
                }
            }

            return primeFactor;
        }

        public static bool IsPrime(long n)
        {
            if (n < 2)
            {
                return false;
            }

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
