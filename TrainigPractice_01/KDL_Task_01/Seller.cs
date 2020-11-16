using System;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_01
{
    class Seller
    {
        private int costCrystals;
        //стоимость кристалов
        public int CostCrystals
        {
            get => costCrystals;
            private set
            {
                if (value > 0)
                    costCrystals = value;
            }
        }

        public Seller(int costCrystals) => this.CostCrystals = costCrystals;

        //предложение покупки
        public void OfferPurchase() => Console.WriteLine($"Продавец:\nПредлагаю вам купить немного кристалов по цене {CostCrystals} за 1 штуку");

    }
}
