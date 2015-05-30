using System;

namespace ProjectEuler
{
    // Find the value of the denominator of the product of four non-trivial fractions
    public class P033
    {
        int nom = 1, den = 1;

        int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public void Check(double ans, char a, char b)
        {
            var x = Char.GetNumericValue(a);
            var y = Char.GetNumericValue(b);
            if (ans == x / y)
            {
                nom *= (int)x;
                den *= (int)y;
            }
        }

        // brute force will easily take less than 1ms
        public int Solve()
        {
            const int n = 100;

            for (int i = 11; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (i % 10 == 0 || j % 10 == 0)
                    {
                        continue;
                    }
                    
                    var ans = (double)i / j;
                    string a = i.ToString(), b = j.ToString();

                    if (a[0] == b[0])
                    {
                        Check(ans, a[1], b[1]);
                    }
                    else if (a[0] == b[1])
                    {
                        Check(ans, a[0], b[1]);
                    }
                    else if (a[1] == b[0])
                    {
                        Check(ans, a[0], b[1]);
                    }
                    else if (a[1] == b[1])
                    {
                        Check(ans, a[0], b[0]);
                    }
                }
            }

            return den / GCD(nom, den);
        }
    }
}
        