using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    // Find the product abc.
    public static class P009
    {
        public static int Solve()
        {
            // it would be impossible for a number to be smaller 
            // than 100 and bigger than 500, considering that
            // a^2 + b^2 = c^2 and a < b < c and a + b + c = 1000 
            int a, b, c = 500;
            for (a = 100; a < 400; a++)
            {
                b = a;

                while (c > ++b)
                {
                    c = 1000 - a - b;

                    if (a * a + b * b == c * c)
                    {
                        return a * b * c;
                    }
                }
            }

            return -1;
        }
    }
}
