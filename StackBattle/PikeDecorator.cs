using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    /// <summary>
    /// Представляет дополнительную функциональность для расширения объекта ArmoredUnit
    /// </summary>
    class PikeDecorator : HeavyUnitDecorator
    {
        public PikeDecorator(HeavyUnit hu=null) : base(hu)
        {
            hu.Pike = true;
        }
    }
}
