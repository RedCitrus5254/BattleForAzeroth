using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.ClassesOfUnits
{
    class Healer : ICanBeHealed, IUnit, ISpecialAction, IClonableToo
    {
        public string Name { get; } = "Healer";
        public int MaxHealth { get; set; } = 60;
        public int Health { get; set; } = 60;
        public int Armour { get; set; } = 0;
        public int Damage { get; set; } = 4;
        public int Range { get; set; } = 3;

        public Healer()
        {

        }
        public Healer(Healer Healer)
        {
            Name = Healer.Name;
            MaxHealth = Healer.MaxHealth;
            Health = Healer.Health;
            Armour = Healer.Armour;
            Damage = Healer.Damage;
        }

        public IUnit Clone()
        {
            return new Healer(this);
        }

        public int DoSpecialAction()
        {
            int result = 1 + Rand.GetRandomNum(10);
            return result;
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
                Console.WriteLine($"Хилер получил {loss} урона");
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
