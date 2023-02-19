using App.Ecs.Player.Score;
using Leopotam.Ecs;

namespace App.Ecs.Player
{
    public sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        public void Init()
        {
            EcsEntity player = _world.NewEntity();

            player.Get<PlayerScoreComponent>();
            player.Get<PlayerScoreChangedEvent>();
        }
    }
}