using System;

namespace KDL_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Player person = new Player();
            Enemy enemy = new Enemy();
            person.CastingSpell();
            while (((IGamePerson)person).HealphPoints > 0 && ((IGamePerson)enemy).HealphPoints > 0)
            {
               person.Move(enemy);
               enemy.Move(person);
            }
        }
    }
}
