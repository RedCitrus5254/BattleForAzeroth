using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    interface ISpecialAction
    {

        int Range { get; set; }
        int DoSpecialAction();
    }
}
