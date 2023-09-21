using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_04
{
    class Program
    {
        static void Main(string[] args)
        {
            // задание 1          
            for (int i = 30; i < 121; i += 3)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------");

            // задание 2
            char letter = 'M';
            for (int i = letter; i < letter + 5; i++)
            {
                Console.WriteLine((char)(i));
            }

            Console.WriteLine();

            // задание 3
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    Console.Write("#" + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // задание 4
            int multiplesOfNumbers = 7;
            int countMultiplesOfNumbers = 0;
            for (int i = -100; i < 1; i++)
            {
                if (i % multiplesOfNumbers == 0)
                {
                    countMultiplesOfNumbers++;
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine($"Количество чисел в диапазоне от -100 до 0 кратных {multiplesOfNumbers}: {countMultiplesOfNumbers}");

            Console.WriteLine();

            // задание 5
            int difference = 10;
            int i = 1;
            int j = 40;

            for (; ; ) // Бесконечный цикл
            {
                Console.WriteLine($"i: {i}, j: {j}");

                if (Math.Abs(i - j) <= difference)
                {
                    break; // Выходим из цикла, если разница между i и j меньше или равна 10
                }

                i++;
                j--;
            }


            
            
        }
    }
}
