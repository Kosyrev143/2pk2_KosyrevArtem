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
            // ввод x и y
            Console.Write("y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            // объявление переменных s, t, v
            double s, t, v;

            // проверка y
            if (y < 2)
            {
                // вычисление значения s
                s = (y - y * Math.Pow(x, 2)) / (x + 1);
            }
            else
            {
                // вычисление значения s
                s = -10.6 * x * y;
            }

            // проверка s
            if (s <= 0)
            {
                // вычисление значения t
                t = y * s + Math.Sin(x) + y;
            }
            else
            {
                // вычисление значения t
                t = s - Math.Pow(Math.Cos(s / x), 2);
            }

            // вычисление значения v
            v = 2 * y * x + 3 * y * s - s * t;

            // вывод s, t, v и их окуругление
            Console.WriteLine($"s: {Math.Round(s, 2)}");
            Console.WriteLine($"t: {Math.Round(t, 2)}");
            Console.WriteLine($"v: {Math.Round(v, 2)}");
        }
    }
}
