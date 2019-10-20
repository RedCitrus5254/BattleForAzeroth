using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    class ThreeToThreeStrategy :IStrategy
    {
        public void AttackOppositeUnit(List<IUnit> firstArmy, List<IUnit> secondArmy)
        {
            for(int i = 0; (i < 3) && (i < firstArmy.Count) && (i<secondArmy.Count); i++)
            {
                secondArmy[i].TakeDamage(firstArmy[i].Damage);
                if (secondArmy[i].Health > 0)
                {
                    firstArmy[i].TakeDamage(secondArmy[i].Damage);
                }
            }
            for(int i=0; (i < 3) && (i < secondArmy.Count) && (i < firstArmy.Count); i++)
            {
                if (secondArmy[i].Health > 0)
                {
                    firstArmy[i].TakeDamage(secondArmy[i].Damage);
                }
            }
        }

        public void UseAbility( List<IUnit> firstArmy, List<IUnit> secondArmy)
        {
            Console.WriteLine("Three To Three");
            for (int i = 3; i < firstArmy.Count; i++) //начинаем с 3 позиции, так как 0, 1, 2 дерутся
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
                        if (i / 3 < unitAction.Range)
                        {
                            int pos;
                            if (secondArmy.Count / 3 <= unitAction.Range - i / 3)
                            {
                                pos = Rand.GetRandomNum(secondArmy.Count);
                            }
                            else
                            {
                                pos = Rand.GetRandomNum(unitAction.Range - (i / 3));
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

                        for (int j = i - unitAction.Range*3; j <= i + unitAction.Range*3; j++)
                        {
                            if (j < 0 || j == i || i % 3 > (j % 3 + unitAction.Range) || (i % 3 + unitAction.Range) < (j % 3))
                            {
                                Console.WriteLine($"Healer {i}не прошёл проверку в цикле");
                                continue;
                            }
                            if (j >= firstArmy.Count)
                            {
                                break;
                            }
                            if (firstArmy[j] is ICanBeHealed && firstArmy[j].MaxHealth > firstArmy[j].Health)
                            {
                                healingUnits.Add(j);
                            }
                        }
                        if (healingUnits.Count > 0)
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
                        if (result == -1)
                        {
                            Console.WriteLine($"{firstArmy[i].Name} {i}: не смог никого клонировать");
                            continue;
                        }
                        else
                        {
                            int pos;
                            List<int> clonableUnits = new List<int>();

                            for (int j = i - unitAction.Range * 3; j <= i + unitAction.Range * 3; j++)
                            {
                                if (j < 0 || j == i || i % 3 > (j % 3 + unitAction.Range) || (i % 3 + unitAction.Range) < (j % 3))
                                {
                                    Console.WriteLine($"wizard {i} не прошёл проверку в цикле");
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
                                int posH = Rand.GetRandomNum(clonableUnits.Count);
                                pos = clonableUnits[posH];

                                firstArmy.Insert(pos, ((IClonable)firstArmy[pos]).Clone()); //добавляем в список юнитов клон
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
                    else if (firstArmy[i].Name.Equals("LightInfantry"))
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

                            for (int j = i - unitAction.Range * 3; j <= i + unitAction.Range * 3; j++)
                            {
                                if (j < 0 || j == i || i % 3 > (j % 3 + unitAction.Range) || (i % 3 + unitAction.Range) < (j % 3))
                                {
                                    Console.WriteLine($"LightInfantry {i} не прошёл проверку в цикле");
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

                                Console.WriteLine($"{firstArmy[i].Name} {i} бафнул {firstArmy[pos].Name} {pos}");
                            }
                            else
                            {
                                Console.WriteLine($"{firstArmy[i].Name} {i}:некого бафать");
                            }
                        }

                    }
                    //unitAction.DoSpecialAction();
                }
            }
        }
    }
}
