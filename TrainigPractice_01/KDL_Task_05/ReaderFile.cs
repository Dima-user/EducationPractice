using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KDL_Task_05
{
    class ReaderFile
    {
        public static char[,] Map { get; set; }
        public static (int, int) Cordinate { get; set; }
        public static int CountStrings { get; private set; } = 0;
        public static int CountSteps { get; set; } = 0;
        public static void ReadFromFile(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string line;
                    //int counter = 0;
                    int lenght = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lenght = line.Length;
                        CountStrings++;
                    }

                    char[,] map = new char[CountStrings, lenght];
                    streamReader.Close();

                    using (StreamReader additionalReader = new StreamReader(path))
                    {
                        CountStrings = 0;

                        while ((line = additionalReader.ReadLine()) != null)
                        {
                            char[] c = line.ToCharArray();
                            for (int i = 0; i < line.Length; i++)
                            {
                                if (c[i] != '*' && c[i] != '<')
                                {
                                    Console.Write(c[i]);
                                    map[CountStrings, i] = c[i];
                                }
                                else if (c[i] != '<')
                                {
                                    Console.Write(" ");
                                    map[CountStrings, i] = ' ';
                                }
                                else
                                {
                                    Console.Write(c[i]);
                                    map[CountStrings, i] = c[i];
                                    Cordinate = (CountStrings, i);
                                }
                            }
                            Console.Write("\n");
                            CountStrings++;
                        }
                    }
                    Map = map;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool Draw((int str,int column) cordinate, (int newStr, int newColumn) newCordinate, string path)
        {
            if (Map[newCordinate.newStr, newCordinate.newColumn] != '#')
            {
                Map[cordinate.str, cordinate.column] = ' ';
                Map[newCordinate.newStr, newCordinate.newColumn] = '<';

                Console.SetCursorPosition(0, 0);

                using (StreamReader stream = new StreamReader(path))
                {
                    for (int iterator = 0; iterator < Map.GetLength(0); iterator++)
                    {
                        for (int aditioanalIterator = 0; aditioanalIterator < Map.GetLength(1); aditioanalIterator++)
                        {
                            Console.Write(Map[iterator, aditioanalIterator]);
                        }
                        Console.WriteLine();
                    }
                    stream.Close();
                }
                CountSteps++;
                Console.WriteLine($"Количество ходов {CountSteps}");
                return true;
            }
            else return false;
            
        }
    }
}
