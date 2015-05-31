using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{

    public static class P025
    {
       public static int Solve()
        {
            int i = 2;
            BigInteger previous = 1, current = 1, temp;

            while (current < BigInteger.Pow(10, 999))
            {
                temp = previous + current;
                previous = current;
                current = temp;
                i++;
            }

            return i;
        }
    }
}
