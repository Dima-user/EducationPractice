using System;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_04
{
    interface IGamePerson
    {
        int HealphPoints { get; set; } 
        int Damage { get; set; }

        void Move(IGamePerson enemy);
    }
}
