using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double[][] array = new double[4][];
            double[] LastNum = new double[4];
            double[] MaxNum = new double[4];
            double[] FirstNum = new double[4];
            // для последнего числа 
            int k = 0;
            // для максимального числа
            int m = 0;
            // для первых чисел
            int f = 0;
            double max = double.MinValue;
            int indexMax = 0;
            double third = 0;
            int indexFirst = 0;
            for (int i = 0; i<4; i++)
            {
                int d = rnd.Next(5, 51);
                array[i] = new double[d];
                for (int j =0; j<d; j++)
                {
                    array[i][j] = rnd.Next(0, 100);
                    Console.Write(array[i][j] + " ");
                    if (j == d - 1)
                    {
                        
                        LastNum[k] = array[i][j];
                        k++;
                    }
                    if(array[i][j] > max)
                    {
                        max = array[i][j];

                    }
                    if(j == 0)
                    {
                        FirstNum[f] = array[i][j];
                        f++;
                    }

                }
                MaxNum[m] = max;
                m++;
                max = double.MinValue;
                
                Console.WriteLine();    
            }
            Console.WriteLine("Задание 3");
            foreach (double x in LastNum)
            {
                Console.Write($"last: {x}");
                Console.WriteLine();
            }
            Console.WriteLine("Задание 4");
            foreach (double x in MaxNum)
            {
                Console.Write($"max: {x}");
                Console.WriteLine();
            }
            foreach (double x in FirstNum)
            {
                Console.Write($"first: {x}");
                Console.WriteLine();
            }


            Console.WriteLine("Задание 5");
            // для замены первого и максиамльного
      
            int forFirst = 0;
            int forMax = 0;
            for (int i = 0; i<4; i++)
            {
                for(int j = 0; j<array[i].Length; j++)
                {
                    if(array[i][j] == FirstNum[forFirst])
                    {
                        array[i][j] = MaxNum[forFirst];
                        
                    }
                    else if(array[i][j] == MaxNum[forMax])
                    {
                        array[i][j] = FirstNum[forMax];
                        
                    }
                    Console.Write(array[i][j] + " ");

                }
                forFirst++;
                forMax++;
                
                Console.WriteLine();
            }

            // реверс
            List<double> newArrayReverse = new List<double>();
            Console.WriteLine("Задание 6");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    newArrayReverse.Add(array[i][j]);
                   // Console.Write($"j: {j}" + " ");
                    
                }
               
                for(int b = newArrayReverse.Count-1; b>-1; b--)
                {
                    Console.Write(newArrayReverse[b] + " ");
                }
                Console.WriteLine();
                newArrayReverse.Clear();
            }

            // вычисление среднего арифметического каждой строки
            double lineSumm = 0;
            Console.WriteLine("Задание 7");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    lineSumm += array[i][j];
                }
                double arithmeticMean = lineSumm / array[i].Length;
                Console.WriteLine($"arithmeticMean: {arithmeticMean}");
                lineSumm = 0;
            }


        }



    }
}
