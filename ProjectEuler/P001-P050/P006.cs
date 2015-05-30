namespace ProjectEuler
{
    // Find the difference between the sum of the squares of the first 
    // one hundred natural numbers and the square of the sum.
    public static class P006
    {
        public static int Solve()
        {
            int n = 100;
            return SqureOfSum(n) - SumOfSquares(n);
        }

        // using differences, we can express sum of consecutive integers as Sn = (n * (n + 1)) / 2
        public static int SqureOfSum(int n)
        {
            int sum = ((n * (n + 1)) / 2);
            return sum * sum;
        }

        // and sum of consecutive squares as S^2n =  (n * (n + 1) * (2n + 1)) / 6
        public static int SumOfSquares(int n)
        {
            return (n * (n + 1) * (2 * n + 1)) / 6;
        }
    }
}
