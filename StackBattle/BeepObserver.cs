using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    [Serializable]
    class BeepObserver : IObserver
    {
        public void Update()
        {
            Console.Beep();
        }
    }
}
