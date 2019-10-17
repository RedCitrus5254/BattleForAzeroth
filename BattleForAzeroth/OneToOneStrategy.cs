using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    

    class OneToOneStrategy : IStrategy
    {
        public void AttackOppositeUnit(List<IUnit> firstArmy, List<IUnit> secondArmy)
        {
            secondArmy[0].TakeDamage(firstArmy[0].Damage);
            if (secondArmy[0].Health > 0)
            {
                firstArmy[0].TakeDamage(secondArmy[0].Damage);
            }
        }

        public void UseAbility( List<IUnit> firstArmy, List<IUnit> secondArmy)
        {
            
            for(int i=1; i< firstArmy.Count;i++)
            {
                ISpecialAction unitAction;
                if (firstArmy[i].Health <= 0) //если юнит мёртв
                {
                    continue;
                }

                unitAction = firstArmy[i] as ISpecialAction;

                if ((unitAction) == null) //если у юнита нет спешл экшена
                {
                    continue;
                }
                else
                {
                    if (firstArmy[i].Name.Equals("Archer"))
                    {
                        if (i < unitAction.Range)
                        {
                            int pos;
                            if(secondArmy.Count <= unitAction.Range - i)
                            {
                                pos = Rand.GetRandomNum(secondArmy.Count);
                            }
                            else
                            {
                                pos = Rand.GetRandomNum(unitAction.Range - i);
                            }
                            int damage = unitAction.DoSpecialAction();
                            secondArmy[pos].TakeDamage(damage);

                            Console.WriteLine($"{firstArmy[i].Name} {i} нанёс {secondArmy[pos].Name} {pos} {damage} урона");
                        }
                        else
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i} слишком далеко");
                        }
                        
                    }
                    else if (firstArmy[i].Name.Equals("Healer"))
                    {
                        int pos;
                        List<int> healingUnits = new List<int>();
                        
                        for(int j = i - unitAction.Range;j <= i + unitAction.Range; j++)
                        {
                            if(j < 0||j==i)
                            {
                                continue;
                            }
                            if (j >= firstArmy.Count)
                            {
                                break;
                            }
                            if(firstArmy[j] is ICanBeHealed && firstArmy[j].MaxHealth > firstArmy[j].Health)
                            {
                                healingUnits.Add(j);
                            }
                        }
                        if (healingUnits.Count>0)
                        {
                            int posH = Rand.GetRandomNum(healingUnits.Count);
                            pos = healingUnits[posH];
                            int heal = unitAction.DoSpecialAction();

                            ((ICanBeHealed)firstArmy[pos]).Heal(heal);
                            Console.WriteLine($"{firstArmy[i].Name} {i} вылечил {firstArmy[pos].Name} {pos} на {heal} хп");
                        }
                        else
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i}: Невозможно никого вылечить");
                        }


                    }
                    else if (firstArmy[i].Name.Equals("Wizard"))
                    {
                        int result = unitAction.DoSpecialAction();
                        if(result == -1)
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i}: не смог никого клонировать");
                            continue;
                        }
                        else
                        {
                            int pos;
                            List<int> clonableUnits = new List<int>();

                            for (int j = i - unitAction.Range; j <= i + unitAction.Range; j++)
                            {
                                if (j < 0 || j == i)
                                {
                                    continue;
                                }
                                if (j >= firstArmy.Count)
                                {
                                    break;
                                }
                                if (firstArmy[j] is IClonable && firstArmy[j].Health > 0)
                                {
                                    clonableUnits.Add(j);
                                }
                            }
                            if (clonableUnits.Count > 0)
                            {
                                foreach(var b in clonableUnits)
                                {
                                    Console.WriteLine(b);
                                }
                                Console.WriteLine(clonableUnits.Count);
                                int posH = Rand.GetRandomNum(clonableUnits.Count);
                                Console.WriteLine(posH + " pos");
                                pos = clonableUnits[posH];

                                firstArmy.Insert(pos, ((IClonable)firstArmy[pos]).Clone());
                                if (pos < i)
                                {
                                    i++;
                                }

                                Console.WriteLine($"{firstArmy[i].Name} {i} клонировал {firstArmy[pos].Name} {pos}");
                            }
                            else
                            {
                                Console.WriteLine($"{firstArmy[i].Name} {i}: невозможно никого клонировать");
                            }
                        }
                    }
                    else if(firstArmy[i].Name.Equals("LightInfantry"))
                    {
                        int result = unitAction.DoSpecialAction();
                        if (result == -1)
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i}: не смог баффнуть тяжёлого пехотинца");
                            continue;
                        }
                        else
                        {
                            int pos;
                            List<int> buffedUnits = new List<int>();

                            for (int j = i - unitAction.Range; j <= i + unitAction.Range; j++)
                            {
                                if (j < 0 || j == i)
                                {
                                    continue;
                                }
                                if (j >= firstArmy.Count)
                                {
                                    break;
                                }
                                if (firstArmy[j].Name.Equals("HeavyInfantry") && firstArmy[j].Health > 0)
                                {
                                    buffedUnits.Add(j);
                                }
                            }
                            if (buffedUnits.Count > 0)
                            {
                                int posH = Rand.GetRandomNum(buffedUnits.Count);
                                pos = buffedUnits[posH];

                                firstArmy[pos] = new ClassesOfUnits.DecoratedHeavyInfantry(firstArmy[pos]);

                                Console.WriteLine($"{firstArmy[i].Name} {i} баффнул {firstArmy[pos].Name} {pos}");
                            }
                            else
                            {
                                Console.WriteLine($"{firstArmy[i].Name} {i}: невозможно никого баффнуть");
                            }
                        }

                    }
                    //unitAction.DoSpecialAction();
                }
            }
        }
    }
}
