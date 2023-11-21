using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите букву для замены: ");
            char letterToAdd = char.Parse(Console.ReadLine());
            Console.Write($"Введите строку в которую добавить букву {letterToAdd}: ");
            string lineIsAdded = Console.ReadLine();
            List<char> listForNewLine = new List<char>();

            int j = 0;
            while (j < lineIsAdded.Length)
            {
                if (lineIsAdded[j] == letterToAdd) // проверяем равен ли элемент строки введенному символу
                {

                    listForNewLine.Add(lineIsAdded[j]); // добавляем в список дополнительный символ
                }

                listForNewLine.Add(lineIsAdded[j]); // добавляем в список все элементы
                j++;
            }
            string value = String.Concat<char>(listForNewLine);
            Console.WriteLine($"Ваша новая строка: {value}");
        }
    }
}
