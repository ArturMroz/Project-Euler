using System.Linq;

namespace ProjectEuler
{
    // What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    class P024
    {
        public static string Solve()
        {
            int[] items = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int count = 1, limit = 1000000;

            while (count < limit)
            {
                int n = items.Length, i = n - 1;

                while (items[i - 1] >= items[i])
                {
                    i--;
                }

                int j = n;
                while (items[j - 1] <= items[i - 1])
                {
                    j--;
                }

                Swap(items, (i++) - 1, j - 1);

                j = n;

                while (i < j)
                {
                    Swap(items, (i++) - 1, (j--) - 1);
                }

                count++;
            }

            // int[] to string
            return items.Aggregate(string.Empty, (s, i) => s + i.ToString());
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
