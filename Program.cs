namespace ПРОЕКТ._Крестики_нолики
{
    internal class Program
    {
        static void Main(string[] args)
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
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "2") flag = true;
                    break;
                }
                if (flag) break;

                Console.WriteLine();

                string[,] gameMap = new string[3, 3] { {"1", "2", "3"}, {"4", "5", "6"}, {"7", "8", "9"} };
                for (int k = 0; k < 9; k++) 
                {
                    
                    if (k % 2 == 0)
                    Console.WriteLine("Сейчас ходят: ");
                    PrintMap(gameMap);
                }
            }
        }
        static void PrintMap(string[,] gameMap) 
        {
            for (int i = 0; i < gameMap.GetLength(0); i++) 
            {
                for (int j = 0; j < gameMap.GetLength(1); j++) 
                {
                    Console.Write(gameMap[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
