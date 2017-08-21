namespace StackBattle
{
    interface ICommand
    {
        void Redo(ref Army a, ref Army b);
        void Undo(ref Army a, ref Army b);
    }
}
