using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    static class Rand
    {
        static Random rnd = new Random();

        public static int GetRandomNum(int max)
        {
            return rnd.Next(max);
        }
        public static int GetRandomNum(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
