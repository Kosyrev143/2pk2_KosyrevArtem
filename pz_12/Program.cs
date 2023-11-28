using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    Реализуйте метод, принимающий двумерный массив и возвращающий транспонированный.
            //        (массив является транспонированным, если в нем поменяли местами строки и столбцы)
            Console.Write("Введите размеры массива: ");
            string str = Console.ReadLine();
            string[] newsTR = str.Split(' ');
            int[][] nums;
            ArrayDeclaration( out nums, newsTR);
            FillingTheArray(nums);


            // вывод
            NormConclusionArray(nums);

            Console.WriteLine();

            int[][] ints = SwapPlaces(nums);

            NormConclusionArray(ints);



        }

        public static void NormConclusionArray(int[][] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < nums[i].Length; j++)
                {
                    Console.Write(nums[i][j] + " ");
                }
            }
        }



        public static int[][] SwapPlaces(int[][] nums)
        {

            int[][] ints = new int[nums[0].Length][];
            string[] newStr = { "5", "5" };
            ArrayDeclaration(out ints, newStr);


            for (int i = 0; i < nums.Length; i++)
            {

                for (int j = 0; j < nums[i].Length; j++)
                {
                    ints[i][j] = nums[j][i];
                }
            }


            return ints;
        }
        


        public static void ArrayDeclaration(out int[][] nums, string[] newStr)
        {
            nums = new int[int.Parse(newStr[0])][];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = new int[int.Parse(newStr[1])];
            }
        }

        public static void FillingTheArray(int[][] nums)
        {

            Random rnd = new Random();
            for(int i = 0; i < nums.Length;i++)
            {
                for(int j = 0; j < nums[i].Length; j++)
                {
                    nums[i][j] = rnd.Next(1, 100);
                }
            }
        }

        
        //public static int[][] SwapPlaces(int[][] nums)
        //{
        //    int intermediateVariable = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        for (int j = 0; j < nums[i].Length; j++)
        //        {
        //            for (int k = j + 1; k < nums[i].Length; k++)
        //            {
        //                // Console.WriteLine($"Следующее: {array[j]}");
        //                if (nums[i][j] > nums[i][k])
        //                {
        //                    intermediateVariable = nums[i][j];
        //                    nums[i][j] = nums[i][k];
        //                    nums[i][k] = intermediateVariable;
        //                }
        //            }
        //        }
        //    }
        //     return nums;
        //}

    }
    
}
