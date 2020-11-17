using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace KDL_Task_04
{
    class RandomFactory
    {
        //для генерации случайного числа
        private readonly static RandomNumberGenerator randomNumber = new RNGCryptoServiceProvider();

        public static int GenerateRandom(int leftEdge, int rightEdge)
        {
            
            byte[] randomByte = new byte[1];
            //получаем случайный байт
            randomNumber.GetBytes(randomByte);

            //преобразуем к числу от 0 до 1
            double randomMultiplier = (randomByte[0] / 255d);

            //разница медду правой и левой границей диапозона
            int differnence = rightEdge - leftEdge;

            //прибавляем к минимальному значение число от 0 до difference 
            int result = leftEdge + (int)Math.Floor(randomMultiplier * differnence);

            return result;
        }
    }
}
