using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_16
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map; //карта
                                                        
        static int playerY = mapSize / 2;   //координаты на карте игрока
        static int playerX = mapSize / 2;  //координаты на карте игрока
        static byte enemies = 10; //количество врагов
        static int countEnemies = 0;
        static int countBuff = 0;
        static int countHealth = 0;
        static byte buffs = 5; //количество усилений
        static int health = 5; // количество аптечек

        // настройки характеристик игрока и врага 
        public static int healthPlayer = 50;
        static int healthEnemies = 30;
        static int damagePlayer = 10;
        static int damageEnemies = 5;

        // максимальное здоровье для аптечки
        static int maxHealth = 50;

        // шаг
        static int countStep = 0;
        // шаг с баффом
        static int countBuffStep = 0;
        static string path;

        static List<int> enymyX = new List<int>();//координаты для сохранения врагов
        static List<int> enymyY = new List<int>();
        static int lex = 0;

        static List<int> buffsX = new List<int>();//координаты для сохранения баффов
        static List<int> buffsY = new List<int>();
        static int lbx = 0;

        static List<int> healthX = new List<int>();//координаты для сохранение аптечек
        static List<int> healthY = new List<int>();
        static int lhx = 0;





        static void Main(string[] args)
        {           
                Prewie();
                Move();
        }

        // начальный экран
        static void Prewie()
        {
            
            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("N - начать новую игру");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("Z - загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            { 
                case ConsoleKey.N: //запуск новой игры     
                     playerY = mapSize / 2;   //координаты на карте игрока
                     playerX = mapSize / 2;
                    countStep = 0;
                    healthPlayer = 50;
                    damagePlayer = 10;
                    enemies = 10; //количество врагов
                    countEnemies = 10;
                    buffs = 5; //количество усилений
                    countBuff = 0;
                    health = 5; // количество аптечек
                    GenerationMap();
                    break;
                case ConsoleKey.Z:
                    Console.Clear();
                    Console.SetCursorPosition(40, 15);
                    Console.Write("Название сохранения: ");
                    Load();
                    break;
                default: //если игрок нажимает на другие клавиши то стартовый экран не пропадает
                    Prewie();
                    break;
            }
        }

        

        static void GenerationMap()
        {
            Random random = new Random();
            map = new char[mapSize, mapSize];
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }

           
            map[playerY, playerX] = 'P'; // в cередину карты ставится игрок
            


            //добавление врагов
            AddEnemies();
            //добавление баффов
            AddBuffs();
            //добавление аптечек
            AddHealth();

            UpdateMap(); //отображение заполненной карты на консоли
            
        }

        static void AddEnemies()
        {
            Random random = new Random();
            while (enemies > 0)
            {
                int x = random.Next(1, mapSize);
                int y = random.Next(1, mapSize);

                //если ячейка пуста - туда добавляется враг
                if (map[x, y] == '_')
                {
                    enymyX.Add(x);
                    enymyY.Add(y);
                    lex++;
                    map[x, y] = 'o';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов

                    
                }
            }
        }

        static void AddBuffs()
        {
            Random random = new Random();
            while (buffs > 0)
            {
                int x = random.Next(1, mapSize);
                int y = random.Next(1, mapSize);

                if (map[x, y] == '_')
                {
                    buffsX.Add(x); 
                    buffsY.Add(y);
                    lbx++;
                    countBuff++;
                    map[x, y] = '^';
                    buffs--;
                }
            }
        }

        static void AddHealth()
        {
             Random random = new Random();
            while (health > 0)
            {
                int x = random.Next(1, mapSize);
                int y = random.Next(1, mapSize);

                if (map[x, y] == '_')
                {
                    healthX.Add(x);
                    healthY.Add(y);
                    lhx++;
                    countHealth++;
                    map[x, y] = '+';
                    health--;
                }
            }
        }

        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    switch (map[i, j])
                    {
                        // вывод расскрашенных элементов
                        case '+':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'o':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case '^':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'P':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;

                        default:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;

                    }
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(map[i, 0]);
                Console.ResetColor();
            }
        }

        static void Move()
        {
            while (true)
            {                
                //предыдущие координаты игрока
                int playerOldY;
                int playerOldX;

                while (true)
                {
                    // время баффа
                    isBuffsStep();
                    Text();

                    playerOldX = playerX;
                    playerOldY = playerY;

                    //смена координат в зависимости от нажатия клавиш
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerX--;
                            countStep++;
                            Text();
                            break;
                        case ConsoleKey.DownArrow:
                            playerX++;
                            countStep++;
                            Text();
                            break;
                        case ConsoleKey.LeftArrow:
                            playerY--;
                            countStep++;
                            Text();
                            break;
                        case ConsoleKey.RightArrow:
                            Text();
                            playerY++;
                            countStep++;
                            break;
                        case ConsoleKey.Q:
                            Pause();
                            break;
                    }

                    // ограничение области движения персонажа
                    if (playerY == mapSize)
                    {
                        playerY = mapSize-1;
                        countStep--;
                    }
                    else if (playerX == mapSize)
                    {
                        playerX = mapSize-1;
                        countStep--;
                    }
                    else if(playerX == -1)
                    {
                        playerX = 0;
                        countStep--;
                    }
                    else if (playerY == -1)
                    {
                        playerY = 0;
                        countStep--;
                    }

                    // выбор проверки в зависимости от того, куда попал персонаж
                    switch (map[playerX, playerY])
                    {
                        case '^':
                            ContactWithBuffs();
                            break;
                        case '+':
                            ContactWithHealth();
                            break;
                        case 'o':
                            ContactWithEnemies();
                            break;
                    }
                   Console.CursorVisible = false; //скрытный курсов

                    //предыдущее положение игрока затирается
                    map[playerOldY, playerOldX] = '_';

                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(playerOldY, playerOldX);
                    Console.Write('_');
                    Console.ResetColor();
                    

                    //обновленное положение игрока
                    map[playerY, playerX] = 'P';
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(playerY, playerX);
                    Console.Write('P');
                    Console.ResetColor();
                    
                    Text();
                }
            }

        }

        // пауза
        static void Pause()
        {

            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("Q - вернуться в игру");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("N - начать новую игру");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("L - сохранить игру");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("Z - загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    Console.Clear();
                    UpdateMap();
                    Move();
                    break;
                case ConsoleKey.N: //запуск новой игры
                    playerY = mapSize / 2;   //координаты на карте игрока
                    playerX = mapSize / 2;
                    countStep = 0; // шаг
                    healthPlayer = 50; // здоровье игрока
                    damagePlayer = 10; // урон игрока
                    enemies = 10; //количество врагов
                    countEnemies = 10; //количество врагов в данный мамент
                    countBuff = 0;
                    countHealth = 0;
                    buffs = 5; //количество усилений
                    health = 5; // количество аптечек
                    GenerationMap();
                    break;
                case ConsoleKey.L: // сохранение в файл
                    Console.Clear();
                    Console.SetCursorPosition(40, 15);
                    Console.Write("Введите название сохранения: ");
                    Save();
                    Console.Clear();
                    Prewie();
                    break;
                case ConsoleKey.Z:
                    Console.Clear();
                    Console.SetCursorPosition(40, 15);
                    Console.Write("Название сохранения: ");
                    Load();
                    break;
                
                
                default: //если игрок нажимает на другие клавиши то стартовый экран не пропадает
                    Pause();
                    break;
            }


        }

        static void Load()
        {
            Console.CursorVisible = true;
            string path = Console.ReadLine();
            string path2 = path + 'w';

            try
            {
                using (FileStream file = new FileStream(path + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        // чтение из файла
                        string[] line = reader.ReadToEnd().Split('\n');
                        playerX = int.Parse(line[0]);
                        playerY = int.Parse(line[1]);
                        enemies = byte.Parse(line[2]);
                        buffs = byte.Parse(line[3]);
                        health = int.Parse(line[4]);
                        healthPlayer = int.Parse(line[5]);
                        damageEnemies = int.Parse(line[6]);
                        damagePlayer = int.Parse(line[7]);
                        countBuffStep = int.Parse(line[8]);
                        countStep = int.Parse(line[9]);
                        countEnemies = int.Parse(line[10]);
                        lex = int.Parse(line[11]);
                        lhx = int.Parse(line[12]);
                        lbx = int.Parse(line[13]);
                        countHealth = int.Parse(line[14]);
                        countBuff = int.Parse(line[15]);    

                    }
                }
                using (FileStream file2 = new FileStream(path2 + ".txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader reader1 = new StreamReader(file2))
                    {
                        // получение координат врагов 
                        Console.Clear();
                        string[] units = reader1.ReadToEnd().Split('\n');
                        int count = 0;
                        enymyX.Clear();
                        enymyY.Clear();
                        buffsX.Clear();
                        buffsY.Clear();
                        healthX.Clear();
                        healthY.Clear();
                        for (int i = 0; i < lex; i++) // координаты врагов
                        {
                            enymyX.Add(int.Parse(units[count]));
                            count++;
                        }
                        for (int i = 0; i < lex; i++)
                        {
                            enymyY.Add(int.Parse(units[count]));
                            count++;
                        }

                        for (int i = 0; i < lhx; i++) // координаты аптечек
                        {
                            healthX.Add(int.Parse(units[count]));
                            count++;
                        }
                        for (int i = 0; i < lhx; i++)
                        {
                            healthY.Add(int.Parse(units[count]));
                            count++;
                        }

                        for (int i = 0; i < lbx; i++) // координаты баффов
                        {
                            buffsX.Add(int.Parse(units[count]));
                            count++;
                        }
                        for (int i = 0; i < lbx; i++)
                        {
                            buffsY.Add(int.Parse(units[count]));
                            count++;
                        }
                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                if (j == 24)
                                {
                                    Console.SetCursorPosition(0, 0);
                                }
                                else
                                {
                                    map[i, j] = '_';
                                }
                            }
                        }
                        //  выставление на карте
                        for (int i = 0; i < lex; i++)
                        {
                            map[enymyX[i], enymyY[i]] = 'o';
                        }
                        for (int i = 0; i < lbx; i++)
                        {
                            map[buffsX[i], buffsY[i]] = '^';
                        }
                        for (int i = 0; i < lhx; i++)
                        {
                            map[healthX[i], healthY[i]] = '+';
                        }
                        // обновление карты
                        UpdateMap();
                        map[playerX, playerY] = 'P';
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('P');
                        Console.ResetColor();
                        Move();
                    }
                }
            }
            catch
            {
                Console.CursorVisible = false;
                
                Console.SetCursorPosition(40, 15);
                Console.WriteLine("Такого сохранения нет... Нажмите любую клавишу");
                Console.SetCursorPosition(40, 16);
                Console.WriteLine("Q - выход в галвное меню");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        Console.Clear();
                        Prewie();
                        Move();
                        break;
                    default:
                        Console.SetCursorPosition(40, 15);
                        Console.Write("Введите название сохранения: ");
                        map[playerY, playerX] = '_';
                        Load();
                        break;
                }


            }
        }

        // сохранение в файл
        static void Save()
        {
            Console.CursorVisible = true;
            string path = Console.ReadLine();
            string path2 = path + 'w';



            using (FileStream file = new FileStream(path + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    // записываем значения переменных
                    writer.WriteLine(playerX);
                    writer.WriteLine(playerY);
                    writer.WriteLine(enemies);
                    writer.WriteLine(buffs);
                    writer.WriteLine(health);
                    writer.WriteLine(healthPlayer);
                    writer.WriteLine(damageEnemies);
                    writer.WriteLine(damagePlayer);
                    writer.WriteLine(countBuffStep);
                    writer.WriteLine(countStep);
                    writer.WriteLine(countEnemies);
                    writer.WriteLine(lex);
                    writer.WriteLine(lhx);
                    writer.WriteLine(lbx);
                    writer.WriteLine(countHealth);
                    writer.WriteLine(countBuff);
                }
            }
            using (FileStream file2 = new FileStream(path2 + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter writer1 = new StreamWriter(file2))
                {
                    // сохранение координат 
                    for (int i = 0; i < enymyX.Count; i++) // врагов
                        writer1.WriteLine(enymyX[i]);
                    for (int i = 0; i < enymyY.Count; i++)
                        writer1.WriteLine(enymyY[i]);

                    for (int i = 0; i < healthX.Count; i++) // аптечек
                        writer1.WriteLine(healthX[i]);
                    for (int i = 0; i < healthY.Count; i++)
                        writer1.WriteLine(healthY[i]);

                    for (int i = 0; i < buffsX.Count; i++) //баффов
                        writer1.WriteLine(buffsX[i]);
                    for (int i = 0; i < buffsY.Count; i++)
                        writer1.WriteLine(buffsY[i]);
                }
            }
        }


        //static void Teleport()
        //{
        //    if (playerY == mapSize - 1)
        //    {
        //        playerY = 0;
        //        countStep--;
        //    }
        //    else if (playerX == mapSize - 1)
        //    {
        //        playerX = 0;
        //        countStep--;
        //    }
        //}

        static void ContactWithHealth()
        {
            if (countHealth == 5)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 9);
                Console.WriteLine("+ - Аптека восстанавливает здоровье игрока на максимум");
                Console.ResetColor();

            }
            else
            {
                Console.SetCursorPosition(40, 9);
                Console.WriteLine("                                                              ");
            }
            for (int i = 0; i < enymyX.Count; i++)
            {
                healthPlayer = maxHealth;
                map[playerX, playerY] = '_';
                healthX.Remove(i);
                healthY.Remove(i);
                lhx--;
                countHealth--;
                Text();
            }
            

        }

        static void ContactWithBuffs()
        {
            if (countBuff == 5)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("^ - Бафф удваивает урон игрока на 20 шагов");
                Console.ResetColor();

            }
            else
            {
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("                                                ");
            }
            for (int i = 0; i < enymyX.Count; i++)
            {
                if (map[playerX, playerY] == '^')
                {
                    
                    countBuffStep = 21;
                    damagePlayer = 20;
                    buffsX.Remove(i);
                    buffsY.Remove(i);
                    lbx--;
                    countBuff--;
                }
            }
            


        }

        //Время действия баффа
        static void isBuffsStep()
        {
           
            if (damagePlayer >= 20) 
            {
                countBuffStep -= 1;
               
                if (countBuffStep <= 0) 
                {
                    damagePlayer = 10; 
                    
                }
                Console.SetCursorPosition(40, 11);
                Console.Write($"Время действия баффа: {countBuffStep}" + " ");
            }

        }

        static void ContactWithEnemies()
        {
            for (int i = 0; i < enymyX.Count; i++)
            {

                if (map[playerX, playerY] == 'o')
                {

                    while (healthPlayer > 0 && healthEnemies > 0)
                    {
                        if(countEnemies == 10)
                        {

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(40, 5);
                            Console.WriteLine("o - Враг(Урон: 5, Здоровье: 30)");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.SetCursorPosition(40, 5);
                            Console.WriteLine("                                           ");
                        }
                        healthEnemies -= damagePlayer;

                        
                        if (healthEnemies <= 0)
                        {
                            countEnemies--;
                            enymyY.RemoveAt(i);
                            enymyX.RemoveAt(i);
                            lex--;
                            if (countEnemies == 0)
                            {
                                WinText();
                            }
                            //Console.SetCursorPosition(60, 5 + i);
                            //Console.Write("Удар");
                            break;
                        }
                        healthPlayer -= damageEnemies;
                        if (healthPlayer <= 0)
                        {
                            Console.Clear();
                            countEnemies = 10;
                            EndText();
                        }

                    }
                    healthEnemies = 30;
                    map[playerX, playerY] = '_';
                }
            }


        }


        static void Text()
        {
            Console.SetCursorPosition(0, mapSize);
            Console.WriteLine($"Жизни игрока: {healthPlayer}" + " ");
            Console.WriteLine($"Количество шагов: {countStep}");
            Console.WriteLine($"Урон игрока: {damagePlayer}");
            Console.WriteLine($"Количество врагов: {countEnemies}" + " ");
        }

        static void WinText()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.Write("ПОБЕДА!!!");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("N - начать новую игру");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("Z - загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            {
                
                case ConsoleKey.N: //запуск новой игры
                    
                    playerY = mapSize / 2;
                     playerX = mapSize / 2;
                    countStep = 0; // шаг
                    healthPlayer = 50; // жизни игрока
                    damagePlayer = 10; // урон игрока
                    enemies = 10; //количество врагов
                    countEnemies = 11; // количество врагов
                    countBuff = 0;
                    buffs = 5; //количество усилений
                    health = 5; // количество аптечек
                    GenerationMap();
                    break;
 
                case ConsoleKey.Z:
                    Console.Clear();
                    Console.SetCursorPosition(40, 15);
                    Console.Write("Название сохранения: ");
                    Load();
                    break;
                default: 
                    WinText();
                    break;
            }
        }

        static void EndText()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.Write("ПРОИГРЫШ...");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("N - начать новую игру");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("Z - загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            {

                case ConsoleKey.N: //запуск новой игры
                    playerY = mapSize / 2;
                     playerX = mapSize / 2;
                    countStep = 0;
                    healthPlayer = 50;
                    damagePlayer = 10;
                    enemies = 10; //количество врагов
                    countEnemies = 11;
                    countBuff = 0;
                    buffs = 5; //количество усилений
                    health = 5; // количество аптечек
                    GenerationMap();
                    break;
                case ConsoleKey.Z:
                    Console.Clear();
                    Console.SetCursorPosition(40, 15);
                    Console.Write("Название сохранения: ");
                    Load();
                    break;
                default: 
                    WinText();
                    break;
            }
        }

    }



    
}
