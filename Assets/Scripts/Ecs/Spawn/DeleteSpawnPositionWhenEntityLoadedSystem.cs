using App.Ecs.Load;
using Leopotam.Ecs;

namespace App.Ecs.Spawn
{
    public sealed class DeleteSpawnPositionWhenEntityLoadedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnPositionComponent, EntityLoadedEvent> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                entity.Del<SpawnPositionComponent>();
            }
        }
    }
}