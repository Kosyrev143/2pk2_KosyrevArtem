using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            double s, t, v;

            if (y < 2)
            {
                s = (y - y * Math.Pow(x, 2)) / (x + 1);
            }
            else
            {
                s = -10.6 * x * y;
            }

            if (s <= 0)
            {
                t = y * s + Math.Sin(x) + y;
            }
            else
            {
                t = s - Math.Pow(Math.Cos(s / x), 2);
            }

            v = 2 * y * x + 3 * y * s - s * t;

            Console.WriteLine($"s: {Math.Round(s, 2)}");
            Console.WriteLine($"t: {Math.Round(t, 2)}");
            Console.WriteLine($"v: {Math.Round(v, 2)}");
        }
    }
}
