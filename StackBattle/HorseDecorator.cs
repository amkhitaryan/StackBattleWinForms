using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    class HorseDecorator : HeavyUnitDecorator
    {
        public HorseDecorator(HeavyUnit hu) : base(hu)
        {
            hu.Horse = true;
        }
    }
}
