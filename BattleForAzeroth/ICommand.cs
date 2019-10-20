using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth
{
    interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }
    /// <summary>
    /// паттерн Команда. Перед методом NextStep() запоминает состояние списков юнитов
    /// </summary>
    class NextStep: ICommand
    {
        private Fabrica fabrica;

        private List<IUnit> firstArmyBefore = new List<IUnit>();
        private List<IUnit> secondArmyBefore = new List<IUnit>();

        private List<IUnit> firstArmyAfter = new List<IUnit>();
        private List<IUnit> secondArmyAfter = new List<IUnit>();

        public NextStep(Fabrica f)
        {
            fabrica = f;
        }

        public void Execute()
        {
            foreach (var i in fabrica.firstTeam)
            {
                firstArmyBefore.Add(((IClonableToo)i).Clone());
            }
            foreach (var i in fabrica.secondTeam)
            {
                secondArmyBefore.Add(((IClonableToo)i).Clone());
            }
            fabrica.NextStep();
            foreach (var i in fabrica.firstTeam)
            {
                firstArmyAfter.Add(((IClonableToo)i).Clone());
            }
            foreach (var i in fabrica.secondTeam)
            {
                secondArmyAfter.Add(((IClonableToo)i).Clone());
            }
        }
        /// <summary>
        /// Отменяет предыдущее действие
        /// </summary>
        public void Undo()
        {
            fabrica.firstTeam.Clear();
            fabrica.secondTeam.Clear();
            foreach (var i in firstArmyBefore)
            {
                fabrica.firstTeam.Add(((IClonableToo)i).Clone());
            }
            foreach (var i in secondArmyBefore)
            {
                fabrica.secondTeam.Add(((IClonableToo)i).Clone());
            }
        }
        /// <summary>
        /// отменяет отмену
        /// </summary>
        public void Redo()
        {
            fabrica.firstTeam.Clear();
            fabrica.secondTeam.Clear();
            foreach (var i in firstArmyAfter)
            {
                fabrica.firstTeam.Add(((IClonableToo)i).Clone());
            }
            foreach (var i in secondArmyAfter)
            {
                fabrica.secondTeam.Add(((IClonableToo)i).Clone());
            }
        }
    }
    /// <summary>
    /// хранит историю действий
    /// </summary>
    class CommandHistory
    {
        private List<ICommand> undoHistory = new List<ICommand>();
        private List<ICommand> redoHistory = new List<ICommand>();

        public void Push(ICommand command)
        {
            undoHistory.Add(command);
        }
        public ICommand PopUndo()
        {
            
            if(undoHistory.Count == 0)
            {
                Console.WriteLine("pop undo");
                return null;
            }
            ICommand command = undoHistory[undoHistory.Count-1];
            command.Undo();
            redoHistory.Add(command);
            undoHistory.RemoveAt(undoHistory.Count - 1);
            return command;
        }
        public ICommand PopRedo()
        {
            if(redoHistory.Count == 0)
            {
                return null;
            }
            ICommand command = redoHistory[redoHistory.Count - 1];
            Push(command);
            command.Redo();
            redoHistory.RemoveAt(redoHistory.Count - 1);
            return command;
        }
        public void ClearRedoHistory()
        {
            redoHistory.Clear();
        }
    }
}
