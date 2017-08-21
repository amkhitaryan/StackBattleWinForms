using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    interface ICommand
    {
        void Redo(ref Army a, ref Army b);
        void Undo(ref Army a, ref Army b);
    }
}
