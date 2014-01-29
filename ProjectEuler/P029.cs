namespace ProjectEuler
{
    // What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
    public static class P029
    {
        public static int Solve()
        {
            int limit = 1001, increment = 20, sum = 24, total = sum;
            
            // with every loop of spiral, increment is growing by 32
            // then it's added to current sum
            for (int i = 3; i < limit; i += 2)
            {
                increment += 32;
                sum += increment;
                total += sum;
            }

            return total + 1;
        }
    }
}
