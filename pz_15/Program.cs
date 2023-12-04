using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            В консоли пользователь вводит строку с полным путем к каталогу в котором содержаться
            //              другие каталоги.Реализовать рекурсивный обход вложенных каталогов и вывод их
            //              содержимого.

            Console.WriteLine("Введите полный путь к каталогу:");
            string forPath = Console.ReadLine();
            string path = $@"{forPath}";


            if (Directory.Exists(path))
            {
                PrintDirectoryContents(path);
            }
            else
            {
                Console.WriteLine("Указанный каталог не существует.");
            }



        }




        static void PrintDirectoryContents(string directoryPath)
        {
            Console.WriteLine($"Содержимое каталога: {directoryPath}");

            try
            {
                string[] files = Directory.GetFiles(directoryPath);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }

                string[] directories = Directory.GetDirectories(directoryPath);

                foreach (string directory in directories)
                {
                    PrintDirectoryContents(directory); // Рекурсивно вызываем метод для вложенных каталогов
                }
                foreach (string dir in directories)
                {
                    string[] arrayFiles = Directory.GetFiles(dir);
                    foreach (string file in arrayFiles)
                    {
                        Console.WriteLine($"Файлы в каталоге {dir}:");
                        Console.WriteLine(file);
                        Console.WriteLine($"Содержимое файла {file}:");
                        FileStream file1 = new FileStream($@"{file}", FileMode.Open, FileAccess.Read);
                        StreamReader reader = new StreamReader(file1);

                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();

                    }
                }
            }
            catch (Exception e)
            {
                // Обработка возможных ошибок доступа к файлам или каталогам
                Console.WriteLine($"Ошибка при попытке получить содержимое каталога: {e.Message}");
            }
        }
    }
}
