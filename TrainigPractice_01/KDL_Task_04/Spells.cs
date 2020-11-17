using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KDL_Task_04
{
    class Spells
    {
        private string[] keys;

        private object[,] arrayElement;

        public int Lenght { get; }

        public Spells(int size)
        {
            keys = new string[size];
            arrayElement = new object[size,2];
            Lenght = size;
        }


        private int Find(string targetKey)
        {
            for (int iterator = 0; iterator < keys.Length; iterator++)
            {
                if (String.Compare(keys[iterator], targetKey) == 0)
                    return iterator;
            }
            return -1;
        }

        private int FindEmpty()
        {
            for (int iterator = 0; iterator < keys.Length; iterator++)
            {
                if (keys[iterator] == null)
                    return iterator;
            }
            throw new Exception("Массив заполнен");
        }

        public object this[string key,int identyficator]
        {
            get
            {
                int index = Find(key);
                if (index < 0)
                    return null;

                return arrayElement[index, identyficator];
            }
            set
            {
                int index = Find(key);
                if (index < 0)
                {
                    index = FindEmpty();
                    keys[index] = key;
                }
                arrayElement[index, identyficator] = value;
            }
        }

        public IEnumerable GetValue (int column, string move)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (move == keys[i])
                {
                    yield return new Tuple<string, object>(keys[i], arrayElement[i, column]);
                    yield break;
                }
            }
        }

        public IEnumerable GetValue(int column)
        {
            for (int i = 0; i < Lenght; i++)
            {
                yield return new Tuple<string, object>(keys[i], arrayElement[i, column]); 
            }
        }
    }
}
