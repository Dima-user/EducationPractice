using System;

namespace KDL_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
           char[] mas = new char[7] { 'a', 'b', 'c', 'd','e','f','g' };

           Shuffle<char> shuffle = new Shuffle<char>(mas);

        }

        
    }
}
