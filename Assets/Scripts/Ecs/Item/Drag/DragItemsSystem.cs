using App.Ecs.Board;
using App.Ecs.Board.Grid;
using App.Ecs.Board.State;
using App.Ecs.Item.Selection;
using App.Ecs.Item.Swap;
using App.Ecs.Item.Swap.Undo;
using App.Extensions;
using App.Services.Board;
using App.Services.Board.Grid;
using App.Services.Input;
using Leopotam.Ecs;

namespace App.Ecs.Item.Drag
{
    public sealed class DragItemsSystem: IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, InputStateTag> _boardFilter;
        private readonly EcsFilter<PositionOnBoardComponent, ItemTag, SelectedTag> _selectedItemFilter;

        private readonly IInputService _inputService;
        private readonly IBoardService _boardService;

        public DragItemsSystem(IInputService inputService, IBoardService boardService)
        {
            _inputService = inputService;
            _boardService = boardService;
        }

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;

            if (_selectedItemFilter.IsEmpty())
                return;

            GridPosition pointerBoardPosition = _boardService.ScreenPointerToBoardItemPosition(_inputService.PointerPosition);

            foreach (int i in _boardFilter)
            {
                ref BoardComponent boardComponent = ref _boardFilter.Get1(i);

                foreach (int j in _selectedItemFilter)
                {
                    ref EcsEntity item = ref _selectedItemFilter.GetEntity(j);
                    ref PositionOnBoardComponent positionOnBoardComponent = ref _selectedItemFilter.Get1(j);

                    if (positionOnBoardComponent.Value == pointerBoardPosition)
                        continue;
                    
                    if (!boardComponent.TryGetAdjacentItemPositionToSwap(
                        positionOnBoardComponent.Value,
                        pointerBoardPosition,
                        out GridPosition adjacentItemPosition
                    ))
                        continue;
                    
                    if (!boardComponent.TryGetBoardItem(adjacentItemPosition, out EcsEntity _))
                        continue;

                    item.Del<SelectedTag>();
                    item.Replace(new SwapRequest(adjacentItemPosition));
                    item.Replace(new UndoSwapComponent(positionOnBoardComponent.Value));
                }
            }
        }
    }
}