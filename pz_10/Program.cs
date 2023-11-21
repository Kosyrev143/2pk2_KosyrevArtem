using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            string[] array = str.Split(' ');

            string promesch;
            for (int i = 0; i < array.Length; i++)
            {
                // Console.WriteLine($"Текущее: {array[i]}");
                for (int j = i + 1; j < array.Length; j++)
                {
                    // Console.WriteLine($"Следующее: {array[j]}");
                    if (array[i].Length > array[j].Length) // если длина текущего больше длины следующего меняем их местами
                    {
                        promesch = array[i];
                        array[i] = array[j];
                        array[j] = promesch;
                    }
                }
            }

            foreach (string s in array) // выводим массив
            {
                Console.Write(s + " ");
            }
        }
    }
}


//string promesch = array[j];
//array[j] = array[j - 1];
//array[j - 1] = promesch;
