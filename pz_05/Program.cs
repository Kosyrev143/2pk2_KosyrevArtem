using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число для которого нужно найти показтель степени числа двойки: ");
            int N = int.Parse(Console.ReadLine());

            // показатель степени
            int degreeIndicator = 1;
            do
            {
                degreeIndicator++;
            } while (Math.Pow(2, degreeIndicator) != N);
            Console.WriteLine(degreeIndicator);

        }
    }
}
