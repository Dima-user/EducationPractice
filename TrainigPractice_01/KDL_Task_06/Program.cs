using System;
using System.Collections;
using System.Collections.Generic;

namespace KDL_Task_06
{
    class Program
    {
        delegate string PrintInformationHandler();
        
        static void Main(string[] args)
        {
            string[] typeName = new string[3] {"Имя ","Фамилия ","Отчество "};
            string[] dossiers = new string[3];
            string[] positions = new string[1];

            string userString = null;
            do
            {
                Console.Clear();
                PrintInformationHandler printInformation = new PrintInformationHandler(Print);
                userString = printInformation.Invoke();

                switch (userString)
                {
                    case "1":
                        {
                            AddDossier(ref dossiers, ref positions, ref typeName);
                            break;
                        }
                    case "2":
                        {
                            PrintDossiers(ref dossiers, ref positions);
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            DeleteDossiers(ref dossiers, ref positions);
                            break;
                        }
                    case "4":
                        {
                            FindSurname(ref dossiers, ref positions);
                            Console.ReadKey();
                            break;
                        }
                        
                }
                

            }
            while (userString != "5");
        }

        static void AddDossier(ref string[] dossiers, ref string[] positions, ref string [] typeName)
        {
            Console.WriteLine("Введите данные через Enter");

            foreach (var c in typeName)
            {
                Console.Write(c + " ");
            }
            Console.Write("\n");
            for (int iterator = dossiers.Length - 3; iterator < dossiers.Length; iterator++)
            {
                dossiers[iterator] = Console.ReadLine();
            }

            Resize(3, ref dossiers);

            Console.Write("Должность ");
            positions[positions.Length - 1] = Console.ReadLine();

            Resize(1, ref positions);
        }

        static void Resize(int size, ref string [] dossiers)
        {
            string[] tempDossiers = dossiers;
            dossiers = new string[tempDossiers.Length + size];
            for (int numerator = 0; numerator < tempDossiers.Length; numerator++)
            {
                dossiers[numerator] = tempDossiers[numerator];
            }

        }

        static void PrintDossiers(ref string[] dossiers, ref string[] positions)
        {
            for (int numerator = 0; numerator < positions.Length; numerator++)
            {
                if(positions[numerator] != null)
                Console.Write("\nНомер досье: {0} {1} - ",numerator + 1,positions[numerator]);

                for (int innerNumerator = numerator * 3; innerNumerator < numerator * 3 + 3; innerNumerator++)
                {
                    if(dossiers[innerNumerator] != null)
                    Console.Write("{0} ", dossiers[innerNumerator]);
                }
                
            }
        }

        static void DeleteDossiers(ref string[] dossiers, ref string[] positions)
        {
            Console.WriteLine("Номер досье для удаления");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Строка неккоректна");
                return;
            }

            for (int numerator = number * 3 - 1; numerator > number * 3 - 4; numerator--)
            {
                dossiers[numerator] = null;
            }

            positions[number - 1] = null;
        }

        static void FindSurname(ref string [] dossiers, ref string [] positions)
        {
            Console.Write("Фамилия: ");
            string SurName = Console.ReadLine();

            for (int iterator = 1; iterator < dossiers.Length; iterator += 3)
            {
                if (SurName == dossiers[iterator])
                {
                    Console.WriteLine("Должность: " + positions[iterator / 3]);
                    for (int j = iterator - 1; j <= iterator + 1; j++)
                    {
                        Console.Write(dossiers[j] + " ");
                    }
                }
            }
        }
        static string Print()
        {
           Console.WriteLine("Выберите команду:\n" +
                             "1 - добавить досье\n"+
                             "2 - вывести все досье\n"+
                             "3 - удалить досье\n"+
                             "4 - поиск по фамилии\n"+
                             "5 - выход из программы");
          return Console.ReadLine();
        }
    }
}
