using System;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_05
{
    class Player
    {
        public static (int str, int column) Cordinate { get; set;}

        public Player((int, int) cordinate)
        {
            Cordinate = cordinate;
        }

        public static (int,int) MoveUp()
        {
            return (Cordinate.str-1, Cordinate.column);   
        }

        public static (int, int) MoveDown()
        {
            return (Cordinate.str + 1, Cordinate.column);
        }

        public static (int, int) MoveRight()
        {
            return (Cordinate.str, Cordinate.column+1);
        }

        public static (int, int) MoveLeft()
        {
            return (Cordinate.str, Cordinate.column-1);
        }
    }
}
