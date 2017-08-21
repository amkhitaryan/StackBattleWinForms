using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    interface IStrategy
    {
        void Combat(Army a, Army b);
    }
}
