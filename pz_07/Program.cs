using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double[,] array = new double[5, 5];
            Console.WriteLine();
            List<double> arraySumm = new List<double>();

            double summ = 0;
            // заполняем двумерный массив рандомными числами
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    array[i, j] = rnd.Next(0, 100);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // вычисляем сумму всех чисел в столбце
            double index = 0;
            while (index < 5)
            {
                for (int i = 0; i < 5; i++)
                {

                    for (int j = 0; j < 5; j++)
                    {
                        if (j == index)
                        {
                            summ += array[i, j];
                        }
                    }

                }
                arraySumm.Add(summ);
                index++;
                summ = 0;
            }

            // вывод результата
            int k = 0;
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Сумма {i} столбца: {arraySumm[k]}");
                k++;
            }


        }
    }
}
