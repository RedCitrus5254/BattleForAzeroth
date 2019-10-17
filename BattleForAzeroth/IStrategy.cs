using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    interface IStrategy
    {
        void AttackOppositeUnit(List<IUnit> firstArmy, List<IUnit> secondArmy);
        void UseAbility(List<IUnit> firstArmy, List<IUnit> secondArmy);
    }
}
