using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pz_14
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //            В текстовый файл построчно записаны фамилия и имя учащихся класса, и его оценка за
            //              контрольную.Вывести на экран всех учащихся, чья оценка меньше 3 баллов и посчитать
            //              средний балл по классу.
            //              Пример содержимого файла:
            //                  Иванов Сергей 5
            //                  Сергеев Иван 2
            //                  Петрова Мария 4
            //              Пример вывода:
            //                  Оценки меньше 3 баллов у:
            //                      Сергеев Иван
            //                  Средний балл по классу: 3,6

            // создать текстовый файл
            string path = @"C:\work\students.txt";
            File.Delete(path);
            FileStream file;
            

            if (!File.Exists(path))
            {
                file = new FileStream(path, FileMode.Create);
                
            }
            else
            {
                file = new FileStream(path, FileMode.Truncate);
            }
            file.Close();
            




            Console.Write("Введите: Фамилия Имя Оценка: ");
            string student = Console.ReadLine();
            while (student != "stop")
            {
                // добавление в тексовый файл
                File.AppendAllText(path, student + "\n");
                Console.Write("Введите: Фамилия Имя Оценка: ");
                student = Console.ReadLine();
            }

            // чтение файла 
            Console.WriteLine("Содержимое файла: ");
            StreamReader reader = new StreamReader(path);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            
            // создание массива линий файла
            string[] lines = File.ReadAllLines(path);
            int min = 5;
            int indexLine = 0;
            double sum = 0;
            double count =0;
 
            for (int i = 0; i < lines.Length; i++)
            {
                sum += int.Parse(lines[i][lines[i].Length - 1].ToString());
                count++;

                if (int.Parse(lines[i][lines[i].Length - 1].ToString()) < min)
                {
                    min = int.Parse(lines[i][lines[i].Length - 1].ToString());
                    indexLine = i;
                }
            }


            double averageScore = Math.Round(sum / count, 2);

            Console.WriteLine("Оценки меньше 3 баллов у:");
            int p = 0;


            while (!"123456789".Contains(lines[indexLine][p]))
            {
                Console.Write(lines[indexLine][p]);
                p++;
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Средний балл по классу: {averageScore}");

            
            
            



             File.Delete(path);

        }

        
    }
}
