using System;

namespace StackBattle
{
    [Serializable]
    class MageUnitFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new Proxy(new MageUnit());
        }
    }
}
