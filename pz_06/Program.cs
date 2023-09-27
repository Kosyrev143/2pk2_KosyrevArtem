using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов масиива: ");
            int n = int.Parse(Console.ReadLine());
            double[] array = new double[n];
            // минимальное и максимальное
            double max = double.MinValue;
            double min = double.MaxValue;
            // сумма для всех элементов массива
            double summ = 0;

            // сортировка масссива
            for (int i=0; i<array.Length; i++)
            {
                double num = double.Parse(Console.ReadLine());
                summ += num;
                array[i] = num;
                if(num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }

            // вычисление произведения
            double compositionMinAndMax = min * max;
            // вычисление суммы
            double amountMinAndMax = min + max;
            // вычисление среднего арифметического
            double arithmeticMean = summ / array.Length;

            Console.WriteLine($"compositionMinAndMax: {compositionMinAndMax}");
            Console.WriteLine($"amountMinAndMax: {amountMinAndMax}");
            Console.WriteLine($"arithmeticMean: {arithmeticMean}");

            
        
        }
    }
}
