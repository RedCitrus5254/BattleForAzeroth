using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    interface IFanfare
    {
        void UpdateUnitsInfo(List<IUnit> units);
    }
}
