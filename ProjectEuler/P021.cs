namespace ProjectEuler
{
    // Evaluate the sum of all the amicable numbers under 10000.
    public static class P021
    {
        // from now on I'm going to put all commonly used methods into Library class
        // and just call methods from there
        public static long Solve()
        {
            int limit = 10000;
            long amicableSum = 0;
            var divisorsSum = new long[limit];

            Library.InitiateSieve(100000);

            for (int i = 1; i < divisorsSum.Length; i++)
            {
                var sum = Library.GetProperDivisorsSum(i);
                divisorsSum[i] = sum;

                if (sum < limit && sum != i && divisorsSum[sum] != 0 && divisorsSum[sum] == i)
                {
                    amicableSum += sum + i;
                }
            }

            return amicableSum;
        }
    }
}
