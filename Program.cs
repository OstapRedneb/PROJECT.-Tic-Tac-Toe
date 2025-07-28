using System.Drawing;

namespace ПРОЕКТ._Крестики_нолики
{
    internal class Program
    {
        static void Main(string[] args) // Игра
        {
            while (true)
            {
                if (!IsStartGame()) 
                    break;

                Console.WriteLine();

                string[,] map = new string[3, 3] 
                {
                    {"1", "2", "3"}, 
                    {"4", "5", "6"}, 
                    {"7", "8", "9"} 
                };

                bool isZeroNow;

                for (int move = 1; move <= 9; move++) 
                {
                    if (move % 2 != 0) isZeroNow = false;
                    else isZeroNow = true;

                    Console.WriteLine(isZeroNow ? "Ходят нолики" : "Ходят крестики");

                    PrintMap(map);
                    Console.WriteLine("Введите цифру вашего хода:");
                    Console.WriteLine();

                    string cellNumber = GetPlayerCellNumber(map);

                    map = MakeMove(map, cellNumber, isZeroNow);

                    if (HasWinner(map)) 
                    {
                        PrintMap(map);

                        Console.WriteLine(isZeroNow ? "Нолики победили!" : "Крестики победили!");

                        Console.WriteLine();
                        break;
                    }
                    if (move == 9)
                    {
                        PrintMap(map);
                        Console.WriteLine("Ничья!");
                    }
                    Console.WriteLine();
                }
            }
        }

        static bool IsStartGame()
        {
            Console.WriteLine("Крестики нолики");
            Console.WriteLine();
            Console.WriteLine("1. Начать игру");
            Console.WriteLine("2. Выйти из игры");
            Console.WriteLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "1")
                    return true;

                if (input == "2")
                    return false;

                Console.WriteLine("Неверный ввод. Пожалуйста, введите 1 или 2.");
            }
        }

        static string GetPlayerCellNumber(string[,] map) 
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9"))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру от 1 до 9.");
                    continue;
                }
                if (!IsMoveCorrect(map, input))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру пустой ячейки.");
                    continue;
                }
                return input;
            }
        }

        static bool HasWinner(string[,] map) // Проверить поле на наличие выигрыша 
        {
            if (map[0, 0] == map[1, 1] && map[0, 0] == map[2, 2]) return true;
            if (map[0, 2] == map[1, 1] && map[0, 2] == map[2, 0]) return true;

            if (map[0, 0] == map[0, 1] && map[0, 0] == map[0, 2]) return true;
            if (map[1, 0] == map[1, 1] && map[1, 0] == map[1, 2]) return true;
            if (map[2, 0] == map[2, 1] && map[2, 0] == map[2, 2]) return true;

            if (map[0, 0] == map[1, 0] && map[0, 0] == map[2, 0]) return true;
            if (map[0, 1] == map[1, 1] && map[0, 1] == map[2, 1]) return true;
            if (map[0, 2] == map[1, 2] && map[0, 2] == map[2, 2]) return true;

            return false;
        }

        static string[,] MakeMove(string[,] map, string cellNumber, bool isZeroNow) // Заменить в поле цифру на символ 
        {
            string mark = isZeroNow ? "O" : "X";

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == cellNumber)
                    {
                        map[i, j] = mark;
                        return map;
                    }
                }
            }

            return map;
        }

        static bool IsMoveCorrect(string[,] map, string cellNumber) // Проверить ввод пользователя на наличие существующего уже хода на поле 
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == cellNumber) return true;
                }
            }
            return false;
        }

        static void PrintMap(string[,] map) // Вывод поля через пробелы 
        {
            for (int i = 0; i < map.GetLength(0); i++) 
            {
                for (int j = 0; j < map.GetLength(1); j++) 
                {
                    if (map[i, j] == "X") Console.ForegroundColor = ConsoleColor.Red;
                    if (map[i, j] == "O") Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(map[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
