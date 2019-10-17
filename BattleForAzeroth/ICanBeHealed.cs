using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    interface ICanBeHealed
    {
        void Heal(int healthCount);
    }
}
