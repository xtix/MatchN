using System;
using System.Collections.Generic;
using App.Core.StateMachine;
using Zenject;

namespace App.Core.Scene
{
    public class SceneGameStateInjector<TBaseState, TContext>: IInitializable, IDisposable
        where TBaseState: IState<TContext>
        where TContext: class
    {
        private readonly IStateManageableStateMachine<TBaseState, TContext> _stateMachine;
        private readonly IEnumerable<TBaseState> _states;

        public SceneGameStateInjector(IStateManageableStateMachine<TBaseState, TContext> stateMachine, IEnumerable<TBaseState> states)
        {
            _stateMachine = stateMachine;
            _states = states;
        }

        public void Initialize()
        {
            foreach (TBaseState state in _states)
                _stateMachine.AddState(state);
        }

        public void Dispose()
        {
            foreach (TBaseState state in _states)
                _stateMachine.RemoveState(state.GetType());
        }
    }
}