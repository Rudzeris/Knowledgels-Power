namespace CodeBase.Infrastructure.States
{
    public interface IStateParam<TParam> : IExitable
    {
        void Enter(TParam arg);
    }
}