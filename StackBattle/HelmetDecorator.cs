using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    class HelmetDecorator : HeavyUnitDecorator
    {
        public HelmetDecorator(HeavyUnit hu) : base(hu)
        {
            hu.Helmet = true;
        }
    }
}
