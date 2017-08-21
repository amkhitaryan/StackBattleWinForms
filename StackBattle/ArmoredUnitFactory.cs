using System;

namespace StackBattle
{
    /// <summary>
    /// Конкретная фабрика для создания объекта ArmoredUnit
    /// </summary>
    [Serializable]
    class ArmoredUnitFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new ArmoredUnit();
        }
    }
}
