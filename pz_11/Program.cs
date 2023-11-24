using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин многоугльника: ");
            int top = Convert.ToInt32(Console.ReadLine());

            int[] arrayX = new int[top];
            int[] arrayY = new int[top];


            Console.WriteLine("Введите координаты точек в формате 'X1 Y1'");
            // заполняем массив X и Y входными координатами
            int y = 1;
            for (int i = 0; i < arrayX.Length; i++)
            {
                Console.Write($"X{y} Y{y}: ");
                string currentXY = Console.ReadLine();
                string[] arrayCurrentXY = currentXY.Split(' ');
                int newX = int.Parse(arrayCurrentXY[0]);
                arrayX[i] = newX;
                int newY = int.Parse(arrayCurrentXY[1]);
                arrayY[i] = newY;
                y++;
            }


            y = 1;
            // выводим значения координат на экран
            Console.WriteLine("Ваши введенные координаты: ");
            for (int i = 0; i < arrayX.Length; i++)
            {
                Console.WriteLine($"X{y}:{arrayX[i]}, Y{y}:{arrayY[i]}");
                y++;
            }


            double perimeter = 0;
            double currentLength;
            for (int i = 1;  i < arrayY.Length; i++) 
            {
                int followingX = arrayX[i]; // следующее X
                int previousX = arrayX[i-1]; // предыдущее X
                int followingY = arrayY[i]; // следующее Y
                int previousY = arrayY[i-1]; // предыдущее Y

                if(i == arrayY.Length-1)
                {
                    int lastFollowingX = arrayX[0]; // следующее X
                    int lastPreviousX = arrayX[arrayX.Length - 1]; // предыдущее X
                    int lastFollowingY = arrayY[0]; // следующее Y
                    int lastPreviousY = arrayY[arrayY.Length - 1]; // предыдущее Y
                    currentLength = Math.Round(CalculatingTheLength(lastFollowingX, lastPreviousX, lastFollowingY, lastPreviousY));
                    Console.WriteLine($"Длина текущего отрезка: {currentLength}");
                    perimeter += currentLength;
                }

                currentLength = Math.Round(CalculatingTheLength(followingX, previousX, followingY, previousY));
                Console.WriteLine($"Длина текущего отрезка: {currentLength}");
                perimeter += currentLength;
            }


            Console.WriteLine($"Периметр многоугольника по заданным точкам: {perimeter}");
        }

        public static double CalculatingTheLength(int followingX, int previousX, int followingY, int previousY)
        {
            double length = Math.Abs(Math.Sqrt(Math.Pow((followingX - previousX), 2) + Math.Pow((followingY - previousY), 2)));
            return length;
        }
    }
}
