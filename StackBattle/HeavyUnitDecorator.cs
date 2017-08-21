using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    /// <summary>
    /// Общий декоратор
    /// </summary>
    public abstract class HeavyUnitDecorator : HeavyUnit
    {
        private HeavyUnit _component;

        protected HeavyUnitDecorator(HeavyUnit hu) 
        {
            if(hu !=null)
                this._component = hu;
        }

    }
}
