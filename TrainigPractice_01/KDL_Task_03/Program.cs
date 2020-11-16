using System;
using System.Collections;

namespace KDL_Task_03
{
    class Program
    {
        class SecretMessage
        {
            private static string Password { get; set; } = "34926";
            private static string Message { get; set; } = "Секрета нет" ;

            public static IEnumerable GetChance(int countChance)
            {
                for (int iterator = 0; iterator < countChance; iterator++)
                {
                    if (iterator > 2)
                    {
                        yield return "Работа программы окончена";
                        yield break;
                    }

                    string password = Console.ReadLine();

                    if (password == Password)
                    {
                        yield return Message;
                        yield break;
                    }
                    else yield return "Пароль не верный";
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введи пароль");

            //можем передать любое число но количество попыток не больше 3
            foreach (var chance in SecretMessage.GetChance(5))
            {
                Console.WriteLine(chance);
            }

            Environment.Exit(0);
        }
    }
}
