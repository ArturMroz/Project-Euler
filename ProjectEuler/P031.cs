using System;

namespace ProjectEuler
{
    // How many different ways can £2 be made using any number of coins
    public static class P031
    {
        public static int Solve()
        {
            int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
//            int[coins.Length] state;

            foreach (var item in coins) {
                Console.WriteLine(item);
            }

            return 0;
        }
    }
}

