namespace StackBattle
{
    interface ICanBeHealed
    {
        int MaxHealth { get; }

        void GetHeal(int hp);
    }
}
