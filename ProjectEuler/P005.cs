using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    public static class P005
    {
        public static long Solve()
        {
            for (int n = 20; ; n++)
            {
                for (int i = 20; i > 1; i--)
                {
                    if (n % i == 0)
                    {
                        if (i == 2)
                        {
                            return n;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
