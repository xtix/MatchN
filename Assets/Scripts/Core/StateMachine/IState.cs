namespace App.Core.StateMachine
{
    public interface IState<TContext> where TContext : class
    {
        void Enter(TContext context);

        void Exit();
    }
}