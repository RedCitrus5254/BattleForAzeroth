using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.ClassesOfUnits
{
    class HeavyInfantry : IUnit
    {
        public string Name { get; } = "HeavyInfantry";
        public int MaxHealth { get; set; } = 100;
        public int Health { get; set; } = 100;
        public int Armour { get; set; } = 3;
        public int Damage { get; set; } = 10;

        public void TakeDamage(int damage)
        {
            int loss = damage - Armour;
            if (loss > 0)
            {
                Health = Health - loss;
                Console.WriteLine($"Тяжёлый пехотинец получил {loss} урона");
            }
        }
        public override string ToString()
        {
            string text = "";
            text += $"{Name}\n";
            text += $"Max HP: {MaxHealth}\n";
            text += $"HP: {Health}\n";
            text += $"Armour: {Armour}\n";
            text += $"Damage: {Damage}";
            return text;
        }
    }
    abstract class Decorator : IUnit
    {
        protected IUnit unit;

        //protected int horse = 30;
        //protected int pike = 5;
        //protected int shield = 1;
        //protected int helm = 1;

        public virtual string Name {
            get
            {
                return unit.Name;
            }
        }
        public virtual int MaxHealth {
            get
            {
                return unit.MaxHealth;
            }
            set
            {
                unit.MaxHealth = value;
            }
        }
        public virtual int Health {
            get
            {
                return unit.Health;
            }
            set
            {
                unit.Health = value;
            }
        }
        public virtual int Armour {
            get
            {
                return unit.Armour;
            }
            set
            {
                unit.Armour = value;
            }
        }
        public virtual int Damage
        {
            get
            {
                return unit.Damage;
            }
            set
            {
                unit.Damage = value;
            }
        }


        public Decorator(IUnit oldUnit)
        {
            unit = oldUnit;
        }
        public void SetUnit(IUnit oldUnit)
        {
            unit = oldUnit;
        }

        public virtual void TakeDamage(int damage)
        {
            unit.TakeDamage(damage);
        }

        
    }

    class DecoratedHeavyInfantry : Decorator
    {
        public DecoratedHeavyInfantry(IUnit unit) : base(unit)
        {

        }

        protected int horseHealth = 30;
        protected int horseMaxHealth = 30;
        protected int pike = 5;
        protected int shield = 1;
        protected int helm = 1;
        public override string Name
        {
            get
            {
                return $"Dec {base.Name}";
            }
        }
        public override int MaxHealth
        {
            get
            {
                return horseMaxHealth + base.MaxHealth;
            }
            set
            {
                base.MaxHealth = value;
            }
        }
        public override int Health
        {
            get
            {
                return horseHealth + base.Health;
            }
            set
            {
                base.Health = value;
            }
        }
        public override int Armour
        {
            get
            {
                return helm + shield + base.Armour;
            }
            set
            {
                base.Armour = value;
            }
        }
        public override int Damage
        {
            get
            {
                return pike + base.Damage;
            }
            set
            {
                base.Damage = value;
            }
        }

        public override void TakeDamage(int damage)
        {
            int loss = damage - shield - helm;
            if (loss > 0)
            {
                int horseDamage = horseHealth - loss;

                if (horseDamage >= 0)
                {
                    horseHealth -= loss;
                    Console.WriteLine($"Лошадь получила {loss} урона");
                }
                else
                {
                    loss -= horseHealth;
                    Console.WriteLine($"Лошадь получила {horseHealth} урона");
                    horseHealth = 0;
                    base.TakeDamage(loss);
                }


                
            }
        }
        public override string ToString()
        {
            string text = "";
            text += $"{Name}\n";
            text += $"Max HP:{MaxHealth}(h({horseMaxHealth}))\n";
            text += $"HP:{Health}(h({horseHealth}))\n";
            text += $"Armour:{Armour}(h({helm}),s({shield}))\n";
            text += $"Damage:{Damage}(p({pike}))";
            return text;
        }
    }
}
