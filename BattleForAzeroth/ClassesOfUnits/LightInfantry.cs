using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.ClassesOfUnits
{
    class LightInfantry : ICanBeHealed, IClonable, IUnit, ISpecialAction
    {
        public string Name { get; } = "LightInfantry";
        public int MaxHealth { get; set; } = 80;
        public int Health { get; set; } = 80;
        public int Armour { get; set; } = 2;
        public int Damage { get; set; } = 8;
        public int Range { get; set; } = 1;

        public LightInfantry()
        {

        }
        public LightInfantry(LightInfantry lightInfantry)
        {
            Name = lightInfantry.Name;
            MaxHealth = lightInfantry.MaxHealth;
            Health = lightInfantry.Health;
            Armour = lightInfantry.Armour;
            Damage = lightInfantry.Damage;
            Range = lightInfantry.Range;
        }

        public IUnit Clone()
        {
            return new LightInfantry(this);
        }

        public int DoSpecialAction()
        {
            int result = 1 + Rand.GetRandomNum(100);
            if (result >= 90)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public void Heal(int healthCount)
        {
            if (MaxHealth > Health + healthCount)
            {
                Health += healthCount;
            }
            else
            {
                Health = MaxHealth;
            }
        }

        public void TakeDamage(int damage)
        {
            int loss = damage - Armour;
            if (loss > 0)
            {
                Health = Health - loss;
                Console.WriteLine($"Лёгкий пехотинец получил {loss} урона");
            }
        }

        public override string ToString()
        {
            string text = "";
            text += $"{Name}\n";
            text += $"Max HP: {MaxHealth}\n";
            text += $"HP: {Health}\n";
            text += $"Armour: {Armour}\n";
            text += $"Damage: {Damage}\n";
            text += $"Range: {Range}";
            return text;
        }
    }
}
