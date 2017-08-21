using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    /// <summary>
    /// Представляет наблюдаемый объект
    /// </summary>
    interface IObservable
    {
        void AddObserver(IObserver obs);
        void RemoveObserver(IObserver obs);
        void NotifyObservers();
    }
}
