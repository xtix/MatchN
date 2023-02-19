using App.Ecs.Load;
using App.Ecs.Spawn;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.View.Position
{
    public sealed class RenderPositionWhenEntityLoadedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PositionableViewComponent, SpawnPositionComponent, EntityLoadedEvent> _filter;

        private readonly IPositionOnBoardService _positionOnBoardService;

        public RenderPositionWhenEntityLoadedSystem(IPositionOnBoardService positionOnBoardService)
        {
            _positionOnBoardService = positionOnBoardService;
        }

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PositionableViewComponent viewComponent = ref _filter.Get1(i);
                ref SpawnPositionComponent spawnPositionComponent = ref _filter.Get2(i);

                viewComponent.View.Position = _positionOnBoardService.PositionOnBoardToWorldPosition(spawnPositionComponent.Value);
            }
        }
    }
}