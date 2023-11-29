using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("задание 1");
            // задание 1
            Console.WriteLine(ArithmeticProgression(-5, 3, 33));
            // задание 2
            Console.WriteLine("задание 2");
            Console.WriteLine(GeometricProgression(-0.6, 5, 1));
            // задание 3
            Console.WriteLine("задание 3");
            int a = 1;
            int b = 5;
            if (a < b)
            {
                ConclusionAB(a, b);
            }
            else
            {
                b -= 1;
                ConclusionBA(a, b);
            }
            // задание 4
            Console.WriteLine("задание 4");
            Console.WriteLine(Summ(2));
        }

        static int ArithmeticProgression(int d, int n, int A1)
        {
            int An = 1;
            if (n != 0)
            {
                An = A1 + d * (n - 1);

                ArithmeticProgression(d, n - 1, A1);
            }
            return An;

        }

        static double GeometricProgression(double q, int n, int B1)
        {
            double Bn = 1;
            if (n != 0)
            {
                Bn = B1 * Math.Pow(q, (n - 1));

                GeometricProgression(q, n - 1, B1);
            }
            return Bn;

        }

        static void ConclusionAB(int a, int b)
        {
            if (a <= b)
            {

                Console.WriteLine(a);
                a++;
                ConclusionAB(a, b);

            }


        }

        static void ConclusionBA(int a, int b)
        {

            if (a > b)
            {

                if (a > b)
                {
                    Console.WriteLine(a);
                    a--;
                    ConclusionBA(a, b);

                }

            }


        }

        static int Summ(int x)
        {

            if (x == 1)
            {
                return 1;
            }
            else
            {
                return x + Summ(x - 1);
            }

        }
    }
}
