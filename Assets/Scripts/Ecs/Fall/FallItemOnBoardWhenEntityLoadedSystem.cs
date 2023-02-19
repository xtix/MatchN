using App.Ecs.Board.Grid;
using App.Ecs.Item;
using App.Ecs.Load;
using App.Ecs.Spawn;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.Fall
{
    public sealed class FallItemOnBoardWhenEntityLoadedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnPositionComponent, PositionOnBoardComponent, ItemTag, EntityLoadedEvent> _spawnedItemFilter;

        public void Run()
        {
            foreach (int i in _spawnedItemFilter)
            {
                ref GridPosition positionOnBoard = ref _spawnedItemFilter.Get2(i).Value;
                GridPosition spawnPosition = _spawnedItemFilter.Get1(i).Value;

                if (positionOnBoard.Y == spawnPosition.Y)
                    continue;
                
                ref EcsEntity item = ref _spawnedItemFilter.GetEntity(i);
                item.Get<FallEvent>();
            }
        }
    }
}