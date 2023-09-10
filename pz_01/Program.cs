using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // ввод данных с клавиатуры и присваивание их переменным
            Console.Write("Введите значения для перменной a в формате(x(число) или x(число) пи / y(число) или пи / y(число)): ");
            string a1 = Console.ReadLine();
            Console.Write("Введите значения для перменной b в формате(x(число) или x(число) пи / y(число) или пи / y(число)): ");
            string b1 = Console.ReadLine();
            Console.Write("Введите значения для перменной c в формате(x(число) или x(число) пи / y(число) или пи / y(число)): ");
            string c1 = Console.ReadLine();


            // объявление перменных
            double a, b, c;

            // массив для разделения переменных по пробелу
            string[] arrayA = new string[0];


            // массив для хранения входных переменных
            string[] lists = new string[] { a1, b1, c1 };

            List<double> newABC = new List<double>();

            for (int i = 0; i < lists.Length; i++)
            {
                if (i == 0)
                {
                    if (lists[i].Contains("/"))
                    {
                        if (lists[i].Length > 7)
                        {
                            arrayA = lists[i].Split(' ');

                            a = (double.Parse(arrayA[0]) * Math.PI) / double.Parse(arrayA[arrayA.Length - 1]);
                            newABC.Add(a);

                        }
                        else
                        {
                            arrayA = lists[i].Split(' ');
                            a = Math.PI / double.Parse(arrayA[arrayA.Length - 1]);
                            newABC.Add(a);
                        }
                    }
                    else
                    {
                        if (lists[i].Contains("пи"))
                        {
                            a = Math.PI;
                            newABC.Add(a);
                        }
                        else
                        {
                            a = double.Parse(lists[i]);
                            newABC.Add(a);
                        }

                    }
                }
                else if (i == 1)
                {
                    if (lists[i].Contains("/"))
                    {
                        if (lists[i].Length > 7)
                        {
                            arrayA = lists[i].Split(' ');

                            b = (double.Parse(arrayA[0]) * Math.PI) / double.Parse(arrayA[arrayA.Length - 1]);
                            newABC.Add(b);

                        }
                        else
                        {
                            arrayA = lists[i].Split(' ');
                            b = Math.PI / double.Parse(arrayA[arrayA.Length - 1]);
                            newABC.Add(b);
                        }
                    }
                    else
                    {
                        if (lists[i].Contains("пи"))
                        {
                            b = Math.PI;
                            newABC.Add(b);
                        }
                        else
                        {
                            b = double.Parse(lists[i]);
                            newABC.Add(b);
                        }

                    }
                }
                else
                {
                    if (lists[i].Contains("/"))
                    {
                        if (lists[i].Length > 7)
                        {
                            arrayA = lists[i].Split(' ');

                            c = (double.Parse(arrayA[0]) * Math.PI) / double.Parse(arrayA[arrayA.Length - 1]);
                            newABC.Add(c);

                        }
                        else
                        {
                            arrayA = lists[i].Split(' ');
                            c = Math.PI / double.Parse(arrayA[arrayA.Length - 1]);
                            newABC.Add(c);
                        }
                    }
                    else
                    {
                        if (lists[i].Contains("пи"))
                        {
                            c = Math.PI;
                            newABC.Add(c);
                        }
                        else
                        {
                            c = double.Parse(lists[i]);
                            newABC.Add(c);
                        }

                    }
                }
            }




            // обявление переменной результата
            double result;

            // первое действие
            double firstAction = Math.Pow(10, 4) * Math.Pow(Math.Sin(2.5 * newABC[2]), 2);
            // второе действие
            double secondAction = (Math.Pow(0.32 * newABC[2], 3) + 4 * newABC[2] + newABC[1]) / Math.Cos(2 * newABC[0]);
            // третье действие
            double thirdAction = Math.Pow(0.32 * Math.Pow(newABC[2], 3) - newABC[1], 1 / 6);
            // четвертое действие
            double fourthAction = Math.Abs(newABC[1]);

            // вычисление
            result = firstAction - secondAction * thirdAction + fourthAction;
            // вывод результата
            Console.WriteLine($"результат: {Math.Round(result, 2)}");
        }
    }
}
