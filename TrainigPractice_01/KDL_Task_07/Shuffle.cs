using System;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_07
{
    class Shuffle<Type>
    {
        public Type []  massive;
        private Random random;

        delegate void ChangingDelegate();

        public delegate void PrintDisplayDelegate();
       

        public Shuffle(Type [] sortedMassive)
        {
            massive = new Type[sortedMassive.Length];
            Array.Copy(sortedMassive, 0, massive, 0, sortedMassive.Length);
            ChangingDelegate change = () => ChangeElement();
            change?.Invoke();

            PrintDisplayDelegate print = () => PrintDisplay();
            print?.Invoke();
        }

        private void ChangeElement()
        {
            random = new Random();

            for (int i = massive.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                Type temp = massive[j];
                massive[j] = massive[i];
                massive[i] = temp;
            }

        }

        private void PrintDisplay()
        {
            Console.WriteLine("\nПоменяный массив");
            for (int iterator = 0; iterator < massive.Length; iterator++)
            {
                Console.Write("{0} ",massive[iterator]);
            }
        }
    }
}
