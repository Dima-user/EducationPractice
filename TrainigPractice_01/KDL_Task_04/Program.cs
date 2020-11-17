using System;

namespace KDL_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            Enemy e = new Enemy();
            p.CastingSpell();
            while (true)
            {
               p.Move(e);
               e.Move(p);
            }
        }
    }
}
