using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.ClassesOfUnits
{
    class Archer : ICanBeHealed, IClonable, IUnit, ISpecialAction
    {
        public string Name { get; } = "Archer";
        public int MaxHealth { get; set; } = 75;
        public int Health { get; set; } = 75;
        public int Armour { get; set; } = 2;
        public int Damage { get; set; } = 6;
        public int Range { get; set; } = 5;

        public Archer()
        {

        }
        public Archer(Archer archer)
        {
            Name = archer.Name;
            MaxHealth = archer.MaxHealth;
            Health = archer.Health;
            Armour = archer.Armour;
            Damage = archer.Damage;
            Range = archer.Range;
        }

        public IUnit Clone()
        {
            return new Archer(this);
        }

        public int DoSpecialAction()
        {
            int result = Rand.GetRandomNum(5);
            return 6 + result;
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
                Console.WriteLine($"Лучник получил {loss} урона");
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
