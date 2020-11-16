using System;

namespace KDL_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            const int COST_CRYSTAL = 7;

            Console.Write("Начальное количество золота:");
            string defaultCountOfGold = Console.ReadLine();

            Customer customer = new Customer(defaultCountOfGold);
            Seller seller = new Seller(COST_CRYSTAL);

            seller.OfferPurchase();

            Console.Write("Вы покупаете кристаллов:");
            string countOfCrystal = Console.ReadLine();
            customer.BuyCrystal(countOfCrystal, seller.CostCrystals);

            customer.PrintCrystalsAndGold();

        }
    }
}

