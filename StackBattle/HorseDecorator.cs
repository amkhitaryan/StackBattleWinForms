namespace StackBattle
{
    class HorseDecorator : HeavyUnitDecorator
    {
        public HorseDecorator(HeavyUnit hu) : base(hu)
        {
            hu.Horse = true;
        }
    }
}
