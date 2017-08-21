using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    interface ISpecialAbility
    {
        void DoSpecialAbility(Army a, Army b, int position, int combatMode);
    }
}
