using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    /// <summary>
    /// Класс для реализации фабричного метода
    /// </summary>
    interface IFactory
    {
        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <returns>Конкретного юнита</returns>
        IUnit CreateUnit();
    }
}
