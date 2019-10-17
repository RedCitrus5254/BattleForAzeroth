using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    class AllToAllStrategy : IStrategy
    {
        public void AttackOppositeUnit(List<IUnit> firstArmy, List<IUnit> secondArmy)
        {
            for(int i = 0; i < firstArmy.Count && i < secondArmy.Count; i++)
            {
                secondArmy[i].TakeDamage(firstArmy[i].Damage);
                if (secondArmy[i].Health > 0)
                {
                    firstArmy[i].TakeDamage(secondArmy[i].Damage);
                }
            }
        }

        public void UseAbility(List<IUnit> firstArmy, List<IUnit> secondArmy)
        {
            int minorArmyCount;
            if (firstArmy.Count > secondArmy.Count)
            {
                minorArmyCount = secondArmy.Count;
            }
            else
            {
                Console.WriteLine("Армии равны, способности не работают.");
                return;
            }

            for(int i = minorArmyCount; i < firstArmy.Count; i++) //начинаем с конца меньшей армии
            {
                ISpecialAction unitAction;

                if (firstArmy[i].Health <= 0)
                {
                    return;
                }

                unitAction = firstArmy[i] as ISpecialAction;
                if ((unitAction) == null) //если у юнита нет спешл экшена
                {
                    continue;
                }

                if (i >= minorArmyCount + unitAction.Range)
                {
                    continue;
                }

                
                else
                {
                    if (firstArmy[i].Name.Equals("Archer"))
                    {
                        int pos;
                        int firstNum = i - unitAction.Range;
                        if (firstNum < 0)
                        {
                            pos = Rand.GetRandomNum(minorArmyCount);
                        }
                        else
                        {
                            pos = Rand.GetRandomNum(firstNum, minorArmyCount);
                        }
                            
                        int damage = unitAction.DoSpecialAction();
                            secondArmy[pos].TakeDamage(damage);

                            Console.WriteLine($"{firstArmy[i].Name} {i} нанёс {secondArmy[pos].Name} {pos} {damage} урона");
                    }
                    else if (firstArmy[i].Name.Equals("Healer"))
                    {
                        List<int> healingUnits = new List<int>();
                        for(int j = i - unitAction.Range; j <= i + unitAction.Range; j++)
                        {
                            if (j < 0 || j==i)
                            {
                                continue;
                            }
                            if (j >= firstArmy.Count)
                            {
                                break;
                            }

                            if(firstArmy[j] is ICanBeHealed)
                            {
                                healingUnits.Add(j);
                            }
                        }

                        int posH;
                        if (healingUnits.Count > 0)
                        {
                            posH = Rand.GetRandomNum(healingUnits.Count);
                        }
                        else
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i} некого хилить");
                            continue;
                        }
                        int pos = healingUnits[posH];

                        ((ICanBeHealed)firstArmy[pos]).Heal(unitAction.DoSpecialAction()); //хилим 
                        Console.WriteLine($"{firstArmy[i].Name} {i} похилил {firstArmy[pos].Name} {pos}");
                    }
                    else if (firstArmy[i].Name.Equals("Wizard"))
                    {
                        int result = unitAction.DoSpecialAction();
                        if (result == -1)
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i} не смог никого копировать");
                            continue;
                        }
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

                            if (firstArmy[j] is IClonable)
                            {
                                clonableUnits.Add(j);
                            }
                        }

                        int posH;
                        if (clonableUnits.Count > 0)
                        {
                            posH = Rand.GetRandomNum(clonableUnits.Count);
                        }
                        else
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i} некого копировать");
                            continue;
                        }
                        int pos = clonableUnits[posH];

                        firstArmy.Insert(pos, ((IClonable)firstArmy[pos]).Clone()); //клонируем

                        if (pos < i)
                        {
                            i++;
                        }

                        Console.WriteLine($"{firstArmy[i].Name} {i} клонировал {firstArmy[pos].Name} {pos}");

                    }
                    else if (firstArmy[i].Name.Equals("LightInfantry"))
                    {
                        int result = unitAction.DoSpecialAction();
                        if (result == -1)
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i}: не смог баффнуть тяжёлого пехотинца");
                            continue;
                        }

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

                        int posH;
                        if (buffedUnits.Count > 0)
                        {
                            posH = Rand.GetRandomNum(buffedUnits.Count);
                        }
                        else
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i}: некого бафать");
                            continue;
                        }
                        int pos = buffedUnits[posH];

                        firstArmy[pos] = new ClassesOfUnits.DecoratedHeavyInfantry(firstArmy[pos]);
                        Console.WriteLine($"{firstArmy[i].Name} {i} баффнул {firstArmy[pos].Name} {pos}");
                    }
                }
            }
        }
    }
}
