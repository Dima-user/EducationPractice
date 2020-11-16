using System;

namespace KDL_Task_02
{
    class Program
    {
        class Infinity
        {
            private static string message;

            public static string Message 
            {
                get => message;
                set => message = value;
            }
            public static void Iteration()
            {
                Console.WriteLine("Цикл все еще выполняется");
            }
        }
        static void Main(string[] args)
        {
            while (Infinity.Message != "exit")
            {
                Infinity.Iteration();
                Infinity.Message = Console.ReadLine();
            }
        }
    }
}
