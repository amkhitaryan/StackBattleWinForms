using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
