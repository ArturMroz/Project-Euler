using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var result = P014.Solve();
            clock.Stop();

            Clipboard.SetText(result.ToString());
            Console.WriteLine("Solution: {0}, calculated in: {1}", result, clock.Elapsed);
            Console.ReadKey();
        }
    }
}
