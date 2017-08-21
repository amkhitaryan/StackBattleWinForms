using System;

namespace StackBattle
{
    /// <summary>
    /// Конкретная фабрика для создания объекта Unit
    /// </summary>
    [Serializable]
    class InfantryUnitFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new InfantryUnit();
        }
    }
}
