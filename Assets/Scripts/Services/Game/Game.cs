using App.Core.StateMachine;
using App.Services.Game.States;
using Zenject;

namespace App.Services.Game
{
    public class Game: IInitializable, ITickable, IGame
    {
        private readonly IStateMachine<StateBase, Game> _stateMachine;

        public Game(IStateMachine<StateBase, Game> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        // Entry point
        public void Initialize()
        {
            ChangeState<BootstrapState>();
        }

        public void Tick()
        {
            _stateMachine.CurrentState.Tick();
        }

        public void Restart()
        {
            _stateMachine.CurrentState.Restart();
        }

        public void ChangeState<TState>() where TState : StateBase
        {
            _stateMachine.ChangeState<TState>(this);
        }
    }
}