namespace ProjectEuler
{
    // Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    class P034
    {
        public static int Solve()
        {
            var factorials = new int[10];
            factorials[0] = factorials[1] = 1;

            // generating factorials cache
            for (int i = 2; i < 10; i++)
            {
                factorials[i] = factorials[i - 1] * i;
            }

            // 9! * 6 = 2177280, so we can set a limit
            int limit = 2177280;
            int totalSum = 0;
            
            for (int i = 10; i < limit; i++)
            {
                int n = i, sum = 0;

                while (n != 0)
                {
                    int t = n % 10;
                    n /= 10;
                    sum += factorials[t];
                }

                if (sum == i) totalSum += i;
            }

            return totalSum;
        }
    }
}
