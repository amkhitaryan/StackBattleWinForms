using System;
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
