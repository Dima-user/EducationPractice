using System;

namespace KDL_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            const int sizeArray = 10;

            Random random = new Random();

            int[] mas = new int[sizeArray];

            Console.WriteLine("Первоначальный массив");

            for (int iterator = 0; iterator < sizeArray; iterator++)
            {
                mas[iterator] = random.Next(10);
                Console.Write("{0} ",mas[iterator]);
            }

           Shuffle<int> shuffle = new Shuffle<int>(mas);

        }

        
    }
}
