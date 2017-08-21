using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StackBattle
{
    /// <summary>
    /// Представляет наблюдателя, который подписывается на все уведомления наблюдаемого объекта.
    /// Определяет метод Update(), который вызывается наблюдаемым объектом для уведомления наблюдателя.
    /// </summary>
    interface IObserver
    {
        void Update();
    }
}
