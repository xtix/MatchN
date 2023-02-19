using System;
using App.Services.SystemComposer;
using Leopotam.Ecs;

namespace App.Services.Game.States
{
    public class GameLoopState : StateBase, IDisposable
    {
        private readonly EcsWorld _world;
        private readonly ISystemComposer _systemComposer;

        private EcsSystems _systems;

        public GameLoopState(EcsWorld world, ISystemComposer systemComposer)
        {
            _world = world;
            _systemComposer = systemComposer;
        }

        public override void Enter(Game context)
        {
            base.Enter(context);

            _systems = _systemComposer.Systems;
        }

        public void Dispose()
        {
            _systems?.Destroy();
            _world.Destroy();
        }

        public override void Tick()
        {
            _systems.Run();
        }

        public override void Restart()
        {
            Game.ChangeState<LoadLevelState>();
        }
    }
}