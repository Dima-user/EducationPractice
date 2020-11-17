using System;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_04
{
    class Enemy : IGamePerson
    {
        int IGamePerson.HealphPoints { get; set; } = RandomFactory.GenerateRandom(500, 1000);
        int IGamePerson.Damage { get; set; } = RandomFactory.GenerateRandom(100, 300);

        public void Move(IGamePerson enemy)
        {
            if (((Player)enemy).Visibile == true)
            {
                Console.WriteLine("Ход БОССА");
                enemy.HealphPoints -= ((IGamePerson)this).Damage;
                PrintResult(enemy);
                ((IGamePerson)this).Damage = RandomFactory.GenerateRandom(100, 500);
            } else PrintResult(enemy);
        }

        void PrintResult(IGamePerson person)
        {
            Console.WriteLine("Cила БОССА {0}", ((IGamePerson)this).Damage);
            Console.WriteLine("Здоровье БОССА {0}\nВаше здоровье {1}", ((IGamePerson)this).HealphPoints, person.HealphPoints);
        }
    }
    
}
