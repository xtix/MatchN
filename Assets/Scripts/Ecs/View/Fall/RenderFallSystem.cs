using App.Ecs.Board.Grid;
using App.Ecs.Fall;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.View.Fall
{
    public sealed class RenderFallSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<FallableViewComponent, PositionOnBoardComponent, FallEvent> _fallableViewFilter;

        private readonly IPositionOnBoardService _positionOnBoardService;

        public RenderFallSystem(IPositionOnBoardService positionOnBoardService)
        {
            _positionOnBoardService = positionOnBoardService;
        }
        
        public void Run()
        {
            foreach (int i in _fallableViewFilter)
            {
                GridPosition positionOnBoard = _fallableViewFilter.Get2(i).Value;
                
                ref FallableViewComponent viewComponent = ref _fallableViewFilter.Get1(i);
                viewComponent.View
                    .FallAsync(_positionOnBoardService.PositionOnBoardToWorldPosition(positionOnBoard))
                    .Forget();
            }
        }
    }
}