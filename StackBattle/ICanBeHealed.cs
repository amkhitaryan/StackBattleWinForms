using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    interface ICanBeHealed
    {
        int MaxHealth { get; }

        void GetHeal(int hp);
    }
}
