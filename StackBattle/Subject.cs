using System;

namespace StackBattle
{
    /// <summary>
    /// Subject для прокси
    /// </summary>
    [Serializable]
    public abstract class  Subject : IUnit, ISpecialAbility, ICanBeHealed
    {
        public abstract void GetHit(double dmg);
        public abstract void GetHeal(int hp);
        public abstract string GetUnitInfo();
        public abstract double Hitpoints { get; protected set; }
        public abstract int Damage { get; protected set; }
        public abstract int Cost { get; }
        public abstract void DoSpecialAbility(Army a, Army b, int position, int combatMode);
        public abstract int MaxHealth { get; }
    }
}
