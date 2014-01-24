using System.Text;

namespace ProjectEuler
{

    public static class P017
    {
        // If all the numbers from 1 to 1000 inclusive were written out in words, how many letters would be used?
        public static int Solve()
        {
            var digits =
                new string[]
                {
                    "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
                };
            var teens =
                new string[]
                {
                    "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
                };
            var tens =
                new string[]
                {
                    "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
                };

            int n;
            StringBuilder number, sum = new StringBuilder();

            for (int i = 1; i < 1000; i++)
            {
                number = new StringBuilder();
                n = i;

                if (n >= 100)
                {
                    int hundreds = n / 100;
                    number.Append(digits[hundreds]);
                    number.Append(" hundred");

                    n %= 100;
                    if (n != 0)
                    {
                        number.Append(" and ");
                    }
                }

                if (n >= 20)
                {
                    int decimalDigit = n / 10;
                    number.Append(tens[decimalDigit]);
                    number.Append(" ");
                    decimalDigit = n % 10;
                    number.Append(digits[decimalDigit]);
                }
                else if (n < 20 && n > 9)
                {
                    number.Append(teens[n - 10]);
                }
                else
                {
                    number.Append(digits[n]);
                }

                sum.Append(number);
            }

            sum.Append("one thousand");
            sum.Replace(" ", string.Empty);
            
            return sum.Length;
        }
    }
}
