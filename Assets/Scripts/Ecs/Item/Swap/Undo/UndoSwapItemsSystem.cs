using App.Ecs.Board;
using App.Ecs.Board.State;
using App.Ecs.Match;
using App.Ecs.Match.Check;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.Item.Swap.Undo
{
    public sealed class UndoSwapItemsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, MatchStateTag> _boardFilter;
        private readonly EcsFilter<ItemTag, CheckMatchRequest> _itemToMatchFilter;
        private readonly EcsFilter<ItemTag, MatchedEvent> _matchedItemFilter;
        private readonly EcsFilter<UndoSwapComponent, ItemTag> _itemToUndoSwapFilter;

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;
            
            if (!_itemToMatchFilter.IsEmpty())
                return;

            if (!_matchedItemFilter.IsEmpty())
                return;

            foreach (int i in _itemToUndoSwapFilter)
            {
                ref EcsEntity entity = ref _itemToUndoSwapFilter.GetEntity(i);
                GridPosition previousPosition = _itemToUndoSwapFilter.Get1(i).PreviousPosition;

                entity.Replace(new SwapRequest(previousPosition));
                entity.Del<UndoSwapComponent>();
            }
        }
    }
}