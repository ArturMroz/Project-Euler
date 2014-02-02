using System;

namespace ProjectEuler
{
    // Find the maximum total from top to bottom of given triangle
    public static class P018
    {
        // variables for brute force solution
        public static int maxSum = 0;
        public static int[,] grid;

        public static int Solve()
        {
            grid = GenerateTable();

            // start from the second bottom row of pyramid
            // to current node add its bigger children
            // proceed all the way up to very first node
            for (int i = grid.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    grid[i, j] += Math.Max(grid[i + 1, j], grid[i + 1, j + 1]);
                }
            }

            return grid[0,0];
        }

        // use recursive function to check all possible values
        public static void BruteForce(int x, int y, int sum)
        {
            var total = sum + grid[x, y];
            if (x == 14)
            {
                if (maxSum < total)
                {
                    maxSum = total;
                }

                return;
            }

            BruteForce(x + 1, y, total);
            BruteForce(x + 1, y + 1, total);
        }

        public static int[,] GenerateTable()
        {
            string input =
                @"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            var lines = input.Replace("\n", "").Split('\r');
            var table = new int[lines.Length, lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var numbers = lines[i].Split(' ');

                for (int j = 0; j < numbers.Length; j++)
                {
                    table[i, j] = Convert.ToInt16(numbers[j]);
                }
            }

            return table;
        }
    }
}
