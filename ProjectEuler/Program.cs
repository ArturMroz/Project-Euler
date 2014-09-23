using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectEuler
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var clock = Stopwatch.StartNew();
            //var result = P040.Solve();
            var result = 1;

            GameOfLife.Initialize();

            clock.Stop();
            Clipboard.SetText(result.ToString());
            Console.WriteLine("Solution: {0}, calculated in: {1}", result, clock.Elapsed);
            Console.ReadKey();
        }
    }
}
