using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // Find the largest palindrome made from the product of two 3-digit numbers.
    public static class P004
    {
        // we can describe palindrome made from the product of two 3-digit numbers as:
        // 100000 * a + 10000 * b + 1000 * c + 100 * c + 10 * b + a
        public static long Solve()
        {
            int maxPalindrome = 0;

            for (int i = 999; i >= 100; i--)
            {
                for (int j = 999; j >= 100; j--)
                {
                    int orignalNumber = i * j, number = orignalNumber;

                    int a = number / 100000;
                    number %= 100000;
                    int b = number / 10000;
                    number %= 10000;
                    int c = number / 1000;
                    number %= 1000;

                    if ((number / 100) == c)
                    {
                        number %= 100;
                        if ((number / 10) == b)
                        {
                            number %= 10;
                            if (number == a)
                            {
                               if (maxPalindrome < orignalNumber)
                               {
                                   maxPalindrome = orignalNumber;
                               }
                            }
                        }
                    }
                }
            }

            return maxPalindrome;
        }

        // way slower solution, using string
        public static int SolveString()
        {
            var maxPalindrome = 0;

            for (int i = 999; i > 100; i--)
            {
                for (int j = 999; j > 100; j--)
                {
                    int number = i * j;
                    string stringNumber = number.ToString();

                    if (stringNumber.Length < 6) break;

                    string firstPart = stringNumber.Remove(3, 3);
                    string secondPart = new string(stringNumber.Remove(0, 3).Reverse().ToArray());

                    if (firstPart == secondPart)
                    {
                        maxPalindrome = maxPalindrome > number ? maxPalindrome : number;
                    }
                }
            }

            return maxPalindrome;
        }
    }
}
