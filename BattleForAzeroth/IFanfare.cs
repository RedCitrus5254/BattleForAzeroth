using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    /// <summary>
    /// Паттерн Observer
    /// </summary>
    interface IFanfare
    {
        void UpdateUnitsInfo(IUnit unit);
    }
}
