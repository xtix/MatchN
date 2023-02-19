using App.Ecs.Board;
using App.Ecs.Board.Grid;
using App.Ecs.View.Swap;
using App.Extensions;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.Item.Swap
{
    public sealed class SwapItemsSystem: IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent> _boardFilter;
        private readonly EcsFilter<SwapRequest, PositionOnBoardComponent, SwappableViewComponent, ItemTag> _itemToSwapFilter;

        private readonly IPositionOnBoardService _positionOnBoardService;

        public SwapItemsSystem(IPositionOnBoardService positionOnBoardService)
        {
            _positionOnBoardService = positionOnBoardService;
        }

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;

            foreach (int i in _boardFilter)
            {
                ref BoardComponent boardComponent = ref _boardFilter.Get1(i);

                foreach (int j in _itemToSwapFilter)
                {
                    ref EcsEntity item = ref _itemToSwapFilter.GetEntity(j);
                    ref SwapRequest request = ref _itemToSwapFilter.Get1(j);

                    if (!boardComponent.TryGetBoardItem(request.TargetPosition, out EcsEntity swapWithItem))
                        continue;

                    ref PositionOnBoardComponent positionOnBoardComponent = ref _itemToSwapFilter.Get2(j);
                    ref SwappableViewComponent itemViewComponent = ref _itemToSwapFilter.Get3(j);

                    boardComponent.SetItemPositionOnBoard(swapWithItem, positionOnBoardComponent.Value);
                    swapWithItem.Get<SwappableViewComponent>().View
                        .MoveAsync(_positionOnBoardService.PositionOnBoardToWorldPosition(positionOnBoardComponent.Value), false)
                        .Forget();

                    boardComponent.SetItemPositionOnBoard(item, request.TargetPosition);
                    itemViewComponent.View
                        .MoveAsync(_positionOnBoardService.PositionOnBoardToWorldPosition(request.TargetPosition), true)
                        .Forget();

                    item.Del<SwapRequest>();
                }
            }
        }
    }
}