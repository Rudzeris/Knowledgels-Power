namespace CodeBase.Infrastructure
{
    public interface IState : IExitable
    {
        void Enter();
    }
}