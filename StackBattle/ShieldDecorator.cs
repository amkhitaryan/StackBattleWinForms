namespace StackBattle
{
    /// <summary>
    /// Представляет дополнительную функциональность для расширения объекта ArmoredUnit
    /// </summary>
    class ShieldDecorator : HeavyUnitDecorator
    {
        public ShieldDecorator(HeavyUnit hu=null) : base(hu)
        {
            hu.Shield = true;
        }
        
    }
}
