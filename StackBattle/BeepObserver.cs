using System;

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
