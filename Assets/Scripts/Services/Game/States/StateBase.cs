using App.Core.StateMachine;

namespace App.Services.Game.States
{
    public abstract class StateBase : IState<Game>
    {
        protected Game Game { get; private set; }

        public virtual void Enter(Game context)
        {
            Game = context;
        }

        public virtual void Exit() {}

        public virtual void Tick() {}

        public virtual void Restart() {}
    }
}