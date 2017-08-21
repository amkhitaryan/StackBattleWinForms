using System;
using System.Collections.Generic;

namespace StackBattle
{
    /// <summary>
    /// Инициатор команды - вызывает команду для выполнения определенного запроса
    /// </summary>
    class Invoker
    {
        internal Stack<ICommand> _commandsUndo = new Stack<ICommand>();
        internal Stack<ICommand> _commandsRedo = new Stack<ICommand>();

        public Tuple<Army, Army> Redo(Army a, Army b)
        {
            if(_commandsRedo.Count == 0) return null;
            _commandsUndo.Push(DeepClone.DoDeepClone(new NextTurnCommand(a,b)));
            _commandsRedo.Peek().Redo(ref a, ref b);
            _commandsRedo.Pop();
            return Tuple.Create(a, b);
        }

        public Tuple<Army,Army> Undo(Army a, Army b)
        {
            if (_commandsUndo.Count == 0) return null;
            _commandsRedo.Push(DeepClone.DoDeepClone(new NextTurnCommand(a,b)));
            _commandsUndo.Peek().Undo(ref a, ref b);
            _commandsUndo.Pop();
            return Tuple.Create(a, b);
        }

        public void AddCommand(NextTurnCommand nextTurnCommand)
        {
            _commandsUndo.Push(nextTurnCommand);
        }

        public void ClearRedo()
        {
            _commandsRedo.Clear();
        }
    }
}
