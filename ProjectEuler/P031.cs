namespace ProjectEuler
{
    // How many different ways can £2 be made using any number of coins
    public static class P031
    {
        public static int Solve()
        {
            int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
            var n = 200;
            var state = new int[n + 1];
            state[0] = 1;

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= n; j++)
                {
                    state[j] += state[j - coins[i]];
                }
            }

            return state[n];
        }
    }
}
        