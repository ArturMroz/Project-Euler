using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var clock = Stopwatch.StartNew();

            var result = P007.Solve();
            clock.Stop();

            Console.WriteLine("Solution: {0}, calculated in: {1}", result, clock.Elapsed);
            Console.ReadKey();
        }
    }
}
