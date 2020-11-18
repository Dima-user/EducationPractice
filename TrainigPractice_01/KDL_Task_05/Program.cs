using System;

namespace KDL_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {  
            ReaderFile.ReadFromFile(@"Map.txt");
            Player player = new Player(ReaderFile.Cordinate);
            
            ConsoleKeyInfo key;

            while (Player.Cordinate.str < ReaderFile.CountStrings-1)
            {  
               key = Console.ReadKey();
                if (key.Key == ConsoleKey.W)
                {
                    if (ReaderFile.Draw(Player.Cordinate, Player.MoveUp(), @"Map.txt"))
                        Player.Cordinate = Player.MoveUp() ;
                }
                if (key.Key == ConsoleKey.S)
                {
                   if( ReaderFile.Draw(Player.Cordinate, Player.MoveDown(), @"Map.txt"))
                    Player.Cordinate = Player.MoveDown();
                }
                if (key.Key == ConsoleKey.D)
                {                    
                    if(ReaderFile.Draw(Player.Cordinate, Player.MoveRight(), @"Map.txt"))
                    Player.Cordinate = Player.MoveRight();
                }
                if (key.Key == ConsoleKey.A)
                {
                    if(ReaderFile.Draw(Player.Cordinate, Player.MoveLeft(), @"Map.txt"))
                    Player.Cordinate = Player.MoveLeft();
                }
            }
            ReaderFile.Draw(Player.Cordinate, Player.MoveRight(), @"Map.txt");
            Console.WriteLine("Вы прошли");
        }
    }
}
