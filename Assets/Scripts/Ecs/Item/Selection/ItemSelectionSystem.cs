using App.Ecs.Board;
using App.Ecs.Board.State;
using App.Ecs.Input.Click;
using App.Extensions;
using App.Services.Board;
using App.Services.Board.Grid;
using Leopotam.Ecs;
using UnityEngine;

namespace App.Ecs.Item.Selection
{
    public sealed class ItemSelectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, InputStateTag> _boardFilter;
        private readonly EcsFilter<ClickEvent> _clickEventFilter;

        private readonly IBoardService _boardService;

        public ItemSelectionSystem(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;
            
            foreach (int i in _clickEventFilter)
            {
                Vector2 pointerPosition = _clickEventFilter.Get1(i).Value;
                GridPosition gridPosition = _boardService.ScreenPointerToBoardItemPosition(pointerPosition);

                foreach (int j in _boardFilter)
                {
                    ref BoardComponent boardComponent = ref _boardFilter.Get1(j);

                    if (!boardComponent.TryGetBoardItem(gridPosition, out EcsEntity item))
                        continue;

                    item.Get<SelectedTag>();

                    return;
                }
            }
        }
    }
}