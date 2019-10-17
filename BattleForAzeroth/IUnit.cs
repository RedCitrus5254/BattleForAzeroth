using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    public interface IUnit
    {
        //характеристики
        string Name { get; }
        int MaxHealth { get; set; }
        int Health { get; set; }
        int Armour { get; set; }
        int Damage { get; set; }

        void TakeDamage(int damage);
    }
}
