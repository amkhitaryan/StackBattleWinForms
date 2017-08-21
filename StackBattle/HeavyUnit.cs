using System;

namespace StackBattle
{
    /// <summary>
    /// Класс компонент для реализации паттерна декоратор
    /// </summary>
    [Serializable]
    public abstract class HeavyUnit
    {
        public bool Shield = false;
        public bool Pike = false;
        public bool Horse = false;
        public bool Helmet = false;
    }
}
