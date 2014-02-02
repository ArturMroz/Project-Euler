using System;

namespace ProjectEuler
{
    // Find the maximum total from top to bottom in triangle.txt
    public static class P067
    {
        public static int Solve()
        {
            var grid = GenerateTable();

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

            return grid[0, 0];
        }

        public static int[,] GenerateTable()
        {
            var lines = ProjectEuler.Properties.Resources.triangle.Split('\n');
            
            // last line in given text file is broken
            var table = new int[lines.Length - 1, lines.Length - 1];

            for (int i = 0; i < lines.Length - 1; i++)
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
