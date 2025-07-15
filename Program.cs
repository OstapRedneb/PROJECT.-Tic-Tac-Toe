using System.Drawing;

namespace ПРОЕКТ._Крестики_нолики
{
    internal class Program
    {
        static void Main(string[] args) // Игра
        {
            while (true)
            {
                bool flag = false;
                Console.WriteLine("Крестики нолики");
                Console.WriteLine();
                Console.WriteLine("1. Начать игру");
                Console.WriteLine("2. Выйти из игры");
                Console.WriteLine();
                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "2") flag = true;
                    break;
                }
                if (flag) break;

                Console.WriteLine();

                string[,] gameMap = new string[3, 3] { {"1", "2", "3"}, {"4", "5", "6"}, {"7", "8", "9"} };

                bool isZerowNow;
                for (int k = 0; k < 9; k++) 
                {
                    if (k % 2 == 0) isZerowNow = false;
                    else isZerowNow = true;
                    
                    if (isZerowNow) Console.WriteLine("Ходят нолики");
                    else Console.WriteLine("Ходят крестики");
                    PrintMap(gameMap);
                    Console.WriteLine("Введите цифру вашего хода:");
                    Console.WriteLine();

                    while (true)
                    {
                        input = Console.ReadLine();
                        Console.Clear();
                        if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9")) continue;
                        if (!InputContains(gameMap, input)) continue;
                        break;
                    }
                    gameMap = FindAndChange(gameMap, input, isZerowNow);

                    if (CheckWiner(gameMap, isZerowNow)) 
                    {
                        if (isZerowNow)
                        {
                            PrintMap(gameMap);
                            Console.WriteLine("Нолики победили!");
                        }
                        else
                        {
                            PrintMap(gameMap);
                            Console.WriteLine("Крестики победили!");
                        }
                        break;
                    }
                    if (k == 8)
                    {
                        PrintMap(gameMap);
                        Console.WriteLine("Ничья!");
                    }
                    Console.WriteLine();
                }
            }
        }
        static bool CheckWiner(string[,] gameMap, bool isZeroNow) // Проверить поле на наличие выигрыша 
        {
            string findChar;
            if (isZeroNow) findChar = "O";
            else findChar = "X";

            int countDiagonal1 = 0;
            int countDiagonal2 = 0;

            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                if (gameMap[i, i] == findChar) countDiagonal1++;
                if (gameMap[i, 2 - i] == findChar) countDiagonal2++;
                if (gameMap[i, 0] == gameMap[i, 1] && gameMap[i, 1] == gameMap[i, 2]) return true;
                if (gameMap[0, i] == gameMap[1, i] && gameMap[0, i] == gameMap[2, i]) return true;
            }

            if (countDiagonal1 == 3 || countDiagonal2 == 3) return true;
            return false;
        }
        static string[,] FindAndChange(string[,] gameMap, string input, bool isZeroNow) // Заменить в поле цифру на символ 
        {
            string result;
            if (isZeroNow) result = "O";
            else result = "X";

            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                for (int j = 0; j < gameMap.GetLength(1); j++)
                {
                    if (gameMap[i, j] == input) gameMap[i, j] = result;
                }
            }

            return gameMap;
        }
        static bool InputContains(string[,] gameMap, string input) // Проверить ввод пользователя на наличие существующего уже хода на поле 
        {
            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                for (int j = 0; j < gameMap.GetLength(1); j++)
                {
                    if (gameMap[i, j] == input) return true;
                }
            }
            return false;
        }
        static void PrintMap(string[,] gameMap) // Вывод поля через пробелы 
        {
            for (int i = 0; i < gameMap.GetLength(0); i++) 
            {
                for (int j = 0; j < gameMap.GetLength(1); j++) 
                {
                    if (gameMap[i, j] == "X") Console.ForegroundColor = ConsoleColor.Red;
                    if (gameMap[i, j] == "O") Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(gameMap[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
