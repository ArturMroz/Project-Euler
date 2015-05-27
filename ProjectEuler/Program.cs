using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            var clock = Stopwatch.StartNew();
            var result = new P033().Solve();
            clock.Stop();
            Console.WriteLine("Solution: {0}, calculated in: {1}", result, clock.Elapsed);
        }
    }
}
