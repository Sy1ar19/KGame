namespace Assets.Scripts.Logic
{
    public interface IAnimatorStateReader
    {
        void EnteredState(int stateHash);
        void ExitedState(int stateHash);

        AnimatorState State { get; }
    }
}