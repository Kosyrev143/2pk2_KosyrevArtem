using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_03
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Отгадайте загадку");
                Console.Write("Вот иголки и булавки\nВыползают из - под лавки,\nНа меня они глядят,\nМолока они хотят.");
                Console.Write("Ответ: ");
                // создаем переменную для ответа
                string answerToTheRiddle = Console.ReadLine();


                // проверка правльного ответа
                switch (answerToTheRiddle.ToLower())
                {
                    case "еж":
                        Console.WriteLine("Вы отгадали загадку!");
                        break;

                    case "сдаюсь":
                        Console.WriteLine("Правильный ответ: еж");
                        break;
                    default:
                        Console.WriteLine("Ответ неверный");
                        break;
                }
                continue;
            }
        }
    }
}
