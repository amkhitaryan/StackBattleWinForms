using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialUnits;

namespace StackBattle
{
    [Serializable]
    class GulyayGorodFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new Adapter(new GulyayGorod());
        }
    }
}
