using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleForAzeroth
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectCaracters());
            //Application.Run(new BattleField());

            //List<IUnit> army1 = new List<IUnit>();
            //List<IUnit> army2 = new List<IUnit>();

            //army1.Add(new ClassesOfUnits.LightInfantry());
            //army1.Add(new ClassesOfUnits.Wizard());
            //army1.Add(new ClassesOfUnits.Archer());
            //army1.Add(new ClassesOfUnits.HeavyInfantry());
            //army2.Add(new ClassesOfUnits.HeavyInfantry());
            //OneToOneStrategy otos = new OneToOneStrategy();
            //otos.UseAbility(army1, army2);

            

            //Console.WriteLine(army1[0].Name + " " + army1[1].Name + " " + army1[2].Name);
            //Console.WriteLine(army1[2].Health);
            //ClassesOfUnits.HeavyInfantry hi = new ClassesOfUnits.HeavyInfantry();
            //ClassesOfUnits.DecoratedHeavyInfantry dhi = new ClassesOfUnits.DecoratedHeavyInfantry(hi);
            //Console.WriteLine(dhi);

            //Console.WriteLine("ХОД ВТОРОЙ АРМИИ");
            //otos.UseAbility(army2, army1);

            //Console.WriteLine("------------");
            //Console.WriteLine(army1[0].Health + " " + army2[0].Health);

            //ClassesOfUnits.HeavyInfantry hi = new ClassesOfUnits.HeavyInfantry();

            //ClassesOfUnits.DecoratedHeavyInfantry dhi = new ClassesOfUnits.DecoratedHeavyInfantry(hi);

            //hi.TakeDamage(10);
            //Console.WriteLine(hi.Health);
            //dhi.TakeDamage(10);
            //Console.WriteLine(dhi.Health);
            //Console.WriteLine(hi.Health);

            //Random rnd = new Random();
            //Console.WriteLine(rnd.Next(0,0));
            //Fabrica f = new Fabrica();
            //f.CreateArmy(1, 1, 0, 2, 1, 3);
        }
    }
}
