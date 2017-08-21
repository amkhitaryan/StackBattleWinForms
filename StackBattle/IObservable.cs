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
