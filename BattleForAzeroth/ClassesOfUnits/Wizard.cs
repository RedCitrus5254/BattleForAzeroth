using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.ClassesOfUnits
{
    class Wizard : ICanBeHealed, IUnit, ISpecialAction, IClonableToo
    {
        public string Name { get; } = "Wizard";
        public int MaxHealth { get; set; } = 70;
        public int Health { get; set; } = 70;
        public int Armour { get; set; } = 1;
        public int Damage { get; set; } = 5;
        public int Range { get; set; } = 2;

        public Wizard()
        {

        }
        public Wizard(Wizard Wizard)
        {
            Name = Wizard.Name;
            MaxHealth = Wizard.MaxHealth;
            Health = Wizard.Health;
            Armour = Wizard.Armour;
            Damage = Wizard.Damage;
        }

        public IUnit Clone()
        {
            return new Wizard(this);
        }

        public int DoSpecialAction()
        {
            int result = Rand.GetRandomNum(100);
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
                Console.WriteLine($"Маг получил {loss} урона");
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
