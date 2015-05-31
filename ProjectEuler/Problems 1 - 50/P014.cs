namespace ProjectEuler
{
    // Which starting number, under one million, produces the longest Collatz sequence?
    public static class P014
    {
        public static int Solve()
        {
            int limit = 1000000, count;
            int n = 1, maxN = 1, maxCount = 1;

            while (n < limit)
            {
                count = CollatzCount(++n);

                if (maxCount < count)
                {
                    maxCount = count;
                    maxN = n;
                }
            }

            return maxN;
        }

        // could cache the already computed sequences
        // but performance wouldn't benefit greatly
        // considering starting numbers are lower than 1000000
        public static int CollatzCount(long n)
        {
            int count = 1;
            while (n != 1)
            {
                n = n % 2 == 0 ? n / 2 : 3 * n + 1;
                count++;
            }

            return count;
        }
    }
}
