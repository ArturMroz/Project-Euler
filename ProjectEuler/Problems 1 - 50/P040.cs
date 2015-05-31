using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
    // find the value of the expression: d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
    // where dx = xth digit of fractorial part of Champernowne's constant
    class P040
    {
        public static long Solve()
        {
            var champernowne = new StringBuilder();
            int i = 0, limit = 1000000, result = 1;

            while (champernowne.Length <= limit)
            {
                champernowne.Append(i);
                i++;
            }

            while (limit > 1)
            {
                result *= (int)Char.GetNumericValue(champernowne[limit]);
                limit /= 10;
            }

            return result;
        }
    }
}
