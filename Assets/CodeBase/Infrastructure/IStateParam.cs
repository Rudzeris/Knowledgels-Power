namespace CodeBase.Infrastructure
{
    public interface IStateParam<TParam> : IExitable
    {
        void Enter(TParam arg);
    }
}