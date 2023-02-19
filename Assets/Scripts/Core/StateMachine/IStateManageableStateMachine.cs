using System;

namespace App.Core.StateMachine
{
    public interface IStateManageableStateMachine<in TBaseState, TContext>
        where TBaseState : IState<TContext>
        where TContext : class
    {
        void AddState(TBaseState state);

        void RemoveState(Type stateType);
    }
}