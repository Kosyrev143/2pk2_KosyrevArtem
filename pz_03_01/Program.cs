using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_03_01
{
    class Program
    {
        static void Main(string[] args)
        {

            // массив в котором хранится 3 тарифа
            string[] rate = new string[] { "Мытье полов", "Мытье потолка", "Общая уборка" };
            // массив в котором хранится цены на тариф
            string[] priceRate = new string[] { "500", "1000", "2500" };
            // список для запоминания имен пользователей
            List<string> listName = new List<string>();

            // переменная суммы цен всех тарифов
            int sum = 0;

            // переменная для счета пользователей
            int countUser = 0;

            // выводим на экран пользователю на экран эти три тарифа
            for (int i=0; i<rate.Length; i++) { 
                Console.WriteLine($"Цена тарифа {rate[i]}: {priceRate[i]}");
            }

            Console.Write("Напишите номер тарифа(1, 2, 3): ");
            string tariffSelection = Console.ReadLine();
            //создать бесконечный цикл  пока не введется пустая строка
            while(tariffSelection != " ")
            {
                string name;
                // условием выбираем какой тариф выбрал пользователь 
                switch (tariffSelection)
                {
                    
                    case "1":
                        Console.Write("Введите имя:");
                        // вводим имя пользователя
                        name = Console.ReadLine();
                        listName.Add(name);
                        // прибавляем сумму тарифа
                        sum += 500;
                        // добавляем к счетчику пользователей 1 
                        countUser++;
                        break;
                    case "2":
                        Console.Write("Введите имя:");
                        // вводим имя пользователя
                        name = Console.ReadLine();
                        listName.Add(name);
                        // прибавляем сумму тарифа
                        sum += 1000;
                        // добавляем к счетчику пользователей 1 
                        countUser++;
                        break;
                    case "3":
                        Console.Write("Введите имя:");
                        // вводим имя пользователя
                        name = Console.ReadLine();
                        listName.Add(name);
                        // прибавляем сумму тарифа
                        sum += 2500;
                        // добавляем к счетчику пользователей 1 
                        countUser++;
                        break;

                }

                // выводим на экран пользователю на экран эти три тарифа
                for (int i = 0; i < rate.Length; i++)
                {
                    Console.WriteLine($"Цена тарифа {rate[i]}: {priceRate[i]}");
                }

                Console.Write("Напишите номер тарифа(1, 2, 3): ");
                tariffSelection = Console.ReadLine();
                continue;
            }

            // выводим на экран общую сумму на всех зарегисрированных пользоваетеллей и их количество 
            Console.WriteLine($"Общая сумма заказов: {sum}");
            Console.WriteLine($"Количество пользователей: {countUser}");
            

        }
    }
}
