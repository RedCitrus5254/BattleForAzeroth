using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    class Proxy : IUnit, IClonableToo
    {
        IUnit heavyInfantry;

        public string Name => ((IUnit)heavyInfantry).Name;

        public int MaxHealth { get => ((IUnit)heavyInfantry).MaxHealth; set => ((IUnit)heavyInfantry).MaxHealth = value; }
        public int Health { get => ((IUnit)heavyInfantry).Health; set => ((IUnit)heavyInfantry).Health = value; }
        public int Armour { get => ((IUnit)heavyInfantry).Armour; set => ((IUnit)heavyInfantry).Armour = value; }
        public int Damage { get => ((IUnit)heavyInfantry).Damage; set => ((IUnit)heavyInfantry).Damage = value; }

        public Proxy(IUnit unit)
        {
            heavyInfantry = unit;
        }

        public override string ToString()
        {
            return "Proxy"+heavyInfantry.ToString();
        }
        public IUnit Clone()
        {
            return new Proxy(((IClonableToo)heavyInfantry).Clone());
        }

        public void TakeDamage(int damage)
        {
            ((IUnit)heavyInfantry).TakeDamage(damage);
        }
    }
}
