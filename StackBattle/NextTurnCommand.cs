using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    [Serializable]
    class NextTurnCommand : ICommand
    {
        //Recievers
        private Army _a;
        private Army _b;

        public NextTurnCommand(Army a, Army b)
        {
            _a = a;
            _b = b;
        }
        public void Redo(ref Army a, ref Army b)
        {
            a = _a.ChangeState(_a);
            b = _b.ChangeState(_b);
        }

        public void Undo(ref Army a, ref Army b)
        {
            a = a.ChangeState(_a);
            b = b.ChangeState(_b);
        }
    }
}
