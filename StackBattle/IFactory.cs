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
