using System;

namespace StackBattle
{
    [Serializable]
    class ArcherUnitFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new ArcherUnit();
        }
    }
}
