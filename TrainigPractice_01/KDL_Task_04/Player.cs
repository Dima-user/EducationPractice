using System;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_04
{

    class Player : IGamePerson
    {
        int IGamePerson.HealphPoints { get; set; } = RandomFactory.GenerateRandom(100, 1000);
        int IGamePerson.Damage { get; set; } = RandomFactory.GenerateRandom(1, 3);

        private int counterMoves;
        public bool Visibile { get; set; } = true;

        public bool ExistSpirit { get; set; } = false;

        private Spells playerSpells;
        public Player()
        {
            Console.WriteLine($"Вы - маг\nваше здоровье: {((IGamePerson)this).HealphPoints} \nваша сила: {((IGamePerson)this).Damage}\n");

            playerSpells = new Spells(6);
            playerSpells["Syringe", 0] = 100;
            playerSpells["New Life", 0] = 200;
            playerSpells["Air Attack", 0] = -100;
            playerSpells["Spirit", 0] = -200;
            playerSpells["Death Ray", 0] =  -250;
            playerSpells["Invisible", 0] = 0;

            playerSpells["Syringe", 1] = "восстанавливает 100 здоровья умноженное на силу";
            playerSpells["New Life",1] = "восстанавливает 200 здоровья умноженное на силу";
            playerSpells["Air Attack",1] = "наносит 100 урона умноженное на силу";
            playerSpells["Spirit",1] = "призывает духа, который наносит 200 урона умноженное на силу";
            playerSpells["Death Ray",1] = "наносит 250 урона умноженное на силу если вызван дух ";
            playerSpells["Invisible",1] = "становитесь невидимым, вы можете только лечиться, но урон по вам не проходит";
        }

       
       public void CastingSpell()
       {
            Console.WriteLine("Ваши заклинания\n");

            foreach (Tuple<string, object> tuple in playerSpells.GetValue(1))
            {
                Console.WriteLine("{0, -10} – {1}",tuple.Item1, tuple.Item2);
            }
               
       }
        public void Move(IGamePerson enemy)
        {
            Console.WriteLine("Ваш ход");
            string move = Console.ReadLine();
            object powerSpell = null;

            foreach (Tuple<string, object> tuple in playerSpells.GetValue(0,move))
            {
                Console.Write("Ваше заклинание: {0}\n", tuple.Item1);
                powerSpell = tuple.Item2;

            }

            if (powerSpell != null)
            {
                if ((int)powerSpell < 0 && counterMoves == 0)
                {
                        if (move == "Spirit" && ExistSpirit == false)
                        {
                        ExistSpirit = true;
                        enemy.HealphPoints += ((IGamePerson)this).Damage * (int)powerSpell;
                        PrintResult(enemy);
                        return;
                        }
                        if (move == "Death Ray" && ExistSpirit == true)
                        {
                        enemy.HealphPoints += ((IGamePerson)this).Damage * (int)powerSpell;
                        PrintResult(enemy);
                        return;
                        }
                        else if (move!="Death Ray")
                        {
                        enemy.HealphPoints += ((IGamePerson)this).Damage * (int)powerSpell;
                        PrintResult(enemy);
                        return;
                        }
                        else
                        { Console.WriteLine("Заклинание Death Ray применить нельзя, вызовите Spirit"); }
                }
                else if ((int)powerSpell > 0)
                {
                    ((IGamePerson)this).HealphPoints += ((IGamePerson)this).Damage * (int)powerSpell;
                    PrintResult(enemy);
                    
                }
                else if ((int)powerSpell == 0 && counterMoves == 0)
                {
                    this.Visibile = false;
                    this.counterMoves = 3;
                    Console.WriteLine("Вы невидимы в течении 3 ходов");
                    Console.WriteLine("Ваше здоровье {0}\nЗдоровье врага {1}", ((IGamePerson)this).HealphPoints, enemy.HealphPoints);
                    return;
                }
                else
                {
                    Console.WriteLine($"Заклинание {move} невозможно применить в данный момент");
                    counterMoves--;
                    return;
                }
                if (counterMoves == 0)
                    Visibile = true;
                else
                    counterMoves--;
            }
            else
            {
                Console.WriteLine($"Заклинания {move} неcуществует");
                if (counterMoves !=0)
                counterMoves--;
                return;
            }
                 
        }

        void PrintResult(IGamePerson person)
        {
            Console.WriteLine("Cила заклинания {0}", ((IGamePerson)this).Damage);
            Console.WriteLine("Ваше здоровье {0}\nЗдоровье врага {1}", ((IGamePerson)this).HealphPoints, person.HealphPoints);
        }
    }
}
