namespace App.Core.StateMachine
{
    public interface IStateMachine<TBaseState, in TContext>
        where TBaseState : IState<TContext>
        where TContext : class
    {
        TBaseState CurrentState { get; }

        void ChangeState<TState>(TContext context) where TState : TBaseState;
    }
}