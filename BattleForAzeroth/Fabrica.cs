using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    class Fabrica
    {
        List<IFanfare> fanfareForms = new List<IFanfare>();
        
        IStrategy strategy = new OneToOneStrategy();

        public List<IUnit> firstTeam { get; set; } = new List<IUnit>();
        public List<IUnit> secondTeam { get; set; } = new List<IUnit>();


        public void NextStep()
        {
            int whoseStep = Rand.GetRandomNum(0, 2);
            if(whoseStep == 0)
            {
                Console.WriteLine("ONE TO ONE");
                strategy.AttackOppositeUnit(firstTeam, secondTeam);
                Console.WriteLine("ABILITY STAGE");
                strategy.UseAbility(firstTeam, secondTeam);
                strategy.UseAbility(secondTeam, firstTeam);
            }
            else if(whoseStep == 1)
            {
                strategy.AttackOppositeUnit(secondTeam, firstTeam);
                strategy.UseAbility(secondTeam, firstTeam);
                strategy.UseAbility(firstTeam, secondTeam);
            }
            foreach(var i in firstTeam)
            {
                Console.WriteLine(i.Name + " HP: " + i.Health);
            }
            Console.WriteLine("..............");
            foreach (var i in secondTeam)
            {
                Console.WriteLine(i.Name + " HP: " + i.Health);
            }
            Console.WriteLine("--------------------");
            CleaningOfCorpses();

        }

        private void CleaningOfCorpses() 
        {
            for(int i=0; i < firstTeam.Count; i++)
            {
                if (firstTeam[i].Health <= 0)
                {
                    Notify(firstTeam[i]);
                    firstTeam.RemoveAt(i);
                    i--;
                }
            }
            for(int i = 0; i < secondTeam.Count; i++)
            {
                if (secondTeam[i].Health <= 0)
                {
                    Notify(secondTeam[i]);
                    secondTeam.RemoveAt(i);
                    i--;
                }
            }
        }
        /// <summary>
        /// Выбор стратегии
        /// </summary>
        public void SetOneToOneStrategy()
        {
            strategy = new OneToOneStrategy();
        }
        public void SetThreeToThreeStrategy()
        {
            strategy = new ThreeToThreeStrategy();
        }
        public void SetAllToAllStrategy()
        {
            strategy = new AllToAllStrategy();
        }

        public int GetCountOfFirstTeam()
        {
            return firstTeam.Count;
        }
        public int GetCountOfSecondTeam()
        {
            return secondTeam.Count;
        }

        public void Subscribe(IFanfare fanfare)
        {
            fanfareForms.Add(fanfare);
        }
        public void UnSubscribe(IFanfare fanfare)
        {
            fanfareForms.Remove(fanfare);
        }

        public void Notify(IUnit unit) 
        {
            foreach(var f in fanfareForms)
            {
                f.UpdateUnitsInfo(unit);
            }
        }

        public void CreateTwoArmys(int[] firstArmy, int[] secondArmy)
        {
            CreateArmy(firstTeam, firstArmy);
            CreateArmy(secondTeam, secondArmy);

            for(int i = 0; i < firstTeam.Count; i++)
            {
                Console.WriteLine(firstTeam[i].Name);
            }
            Console.WriteLine("------------");
            for (int i = 0; i < secondTeam.Count; i++)
            {
                Console.WriteLine(secondTeam[i].Name);
            }
        }

        public void CreateArmy(List<IUnit> army, int[] numOfUnitsInArmy)
        {
            
            for(int i = 0; i < numOfUnitsInArmy[0]; i++)
            {
                army.Add(new ClassesOfUnits.LightInfantry());
            }
            for (int i = 0; i < numOfUnitsInArmy[1]; i++)
            {
                army.Add(new Proxy(new ClassesOfUnits.HeavyInfantry()));
            }
            for (int i = 0; i < numOfUnitsInArmy[2]; i++)
            {
                army.Add(new ClassesOfUnits.Archer());
            }
            for (int i = 0; i < numOfUnitsInArmy[3]; i++)
            {
                army.Add(new ClassesOfUnits.Healer());
            }
            for (int i = 0; i < numOfUnitsInArmy[4]; i++)
            {
                army.Add(new ClassesOfUnits.Wizard());
            }

            int numOfUnits = numOfUnitsInArmy[0] + numOfUnitsInArmy[1] + numOfUnitsInArmy[2] + numOfUnitsInArmy[3] + numOfUnitsInArmy[4];
            
            IUnit unit;

            for(int i = 0; i < numOfUnits; i++)
            {
                int val = Rand.GetRandomNum(numOfUnits);
                unit = army[val];
                army[val] = army[i];
                army[i] = unit;
            }
            
        }
    }
}
