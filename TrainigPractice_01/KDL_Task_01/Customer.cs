using System;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_01
{
    class Customer
    {
        //Золото и кристалы покупателя
        private int gold;
        private int crystal;

        //для доступа и установки количества золота
        public int Gold
        {
            get => gold;

        }

        //для доступа и установки количества кристаллов
        public int Crystal
        {
            get => crystal;

        }

        //начальное количество золота покупателя
        public Customer(string countOfGoldAsString)
        {
            if (int.TryParse(countOfGoldAsString, out int countOfGold))
                this.gold = countOfGold;
            else throw new ArgumentException("Строка неккоректна");
        }


        public void BuyCrystal(in string countOfCrystalAsString, in int costCrystal)
        {
            //проверка на корректность строки
            if (int.TryParse(countOfCrystalAsString, out int countOfCrystal))
            {
                //конвертация золота в кристалы
                int goldSum = costCrystal * countOfCrystal;

                SetValue(goldSum, countOfCrystal);
            }
            else throw new ArgumentException("Строка неккоректна");

        }

        private void SetValue(int goldSum, int countCrystal)
        {
            //если нельзя купить то выходим из функции
            if (goldSum > this.gold)
                return;
            this.gold -= goldSum;
            this.crystal += countCrystal;
        }

        public void PrintCrystalsAndGold()
        {
            Console.WriteLine($"Теперь у вас {Crystal} кристаллов и {Gold} золота");
        }
    }
}
