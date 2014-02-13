using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    // Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    class P032
    {
        public static int Solve()
        {
            var digits = new HashSet<int>();
            var pandigitals = new HashSet<int>();

            for (int i = 1234; i < 9876; i++)
            {
                //var primeFactors = Library.GetPrimeFactors(i);
                var divisors = Library.GetAllDivisors(i);

                for (int j = 1; j < (divisors.Count) / 2; j++)
                {
                    digits.Clear();
                    
                    digits.UnionWith(Library.NumberToList((int)divisors[j]));
                    digits.UnionWith(Library.NumberToList((int)divisors[divisors.Count - 1 - j]));
                    digits.UnionWith(Library.NumberToList(i));

                    if (digits.Count == 9 && !digits.Contains(0))
                    {
                        pandigitals.Add(i);
                    }
                }
            }

            return pandigitals.Sum();
        }
    }
}
