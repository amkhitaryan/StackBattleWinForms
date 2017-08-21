namespace StackBattle
{
    class HelmetDecorator : HeavyUnitDecorator
    {
        public HelmetDecorator(HeavyUnit hu) : base(hu)
        {
            hu.Helmet = true;
        }
    }
}
