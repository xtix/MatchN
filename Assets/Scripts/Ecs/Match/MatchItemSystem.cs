using System.Collections.Generic;
using App.Ecs.Board;
using App.Ecs.Board.Grid;
using App.Ecs.Board.State;
using App.Ecs.Item;
using App.Ecs.Match.Check;
using App.Ecs.View.Animation;
using App.Extensions;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.Match
{
    public sealed class MatchItemSystem: IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, MatchStateTag> _boardFilter;
        private readonly EcsFilter<ItemTag, AnimatedTag> _animatedItemFilter;
        private readonly EcsFilter<PositionOnBoardComponent, ItemTypeComponent, ItemTag, CheckMatchRequest> _itemToMatchFilter;

        private readonly int _matchCount;

        private readonly List<EcsEntity> _matches = new();

        public MatchItemSystem(int matchCount)
        {
            _matchCount = matchCount;
        }

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;
            
            if (_itemToMatchFilter.IsEmpty())
                return;

            if (!_animatedItemFilter.IsEmpty())
                return;

            foreach (int i in _boardFilter)
            {
                ref BoardComponent boardComponent = ref _boardFilter.Get1(i);

                foreach (int j in _itemToMatchFilter)
                {
                    ref EcsEntity item = ref _itemToMatchFilter.GetEntity(j);
                    item.Del<CheckMatchRequest>();
                    
                    if (item.Has<MatchedEvent>())
                        continue;

                    FindHorizontalMatches(boardComponent, item);
                    if (_matches.Count >= _matchCount)
                        foreach (EcsEntity entity in _matches)
                            entity.Get<MatchedEvent>();
                    
                    _matches.Clear();

                    FindVerticalMatches(boardComponent, item);
                    if (_matches.Count >= _matchCount)
                        foreach (EcsEntity entity in _matches)
                            entity.Get<MatchedEvent>();

                    _matches.Clear();
                }
            }
        }

        private void FindHorizontalMatches(in BoardComponent boardComponent, in EcsEntity item)
        {
            _matches.Add(item);

            GridPosition itemPosition = item.Get<PositionOnBoardComponent>().Value;
            int itemType = item.Get<ItemTypeComponent>().Value;

            for (int x = itemPosition.X - 1; x >= 0; x--)
                if (TryGetMatch(boardComponent, x, itemPosition.Y, itemType, out EcsEntity match))
                    _matches.Add(match);
                else
                    break;

            for (int x = itemPosition.X + 1; x < boardComponent.BoardSize.X; x++)
                if (TryGetMatch(boardComponent, x, itemPosition.Y, itemType, out EcsEntity match))
                    _matches.Add(match);
                else
                    break;
        }

        private void FindVerticalMatches(in BoardComponent boardComponent, in EcsEntity item)
        {
            _matches.Add(item);

            GridPosition itemPosition = item.Get<PositionOnBoardComponent>().Value;
            int itemType = item.Get<ItemTypeComponent>().Value;

            for (int y = itemPosition.Y - 1; y >= 0; y--)
                if (TryGetMatch(boardComponent, itemPosition.X, y, itemType, out EcsEntity match))
                    _matches.Add(match);
                else
                    break;

            for (int y = itemPosition.Y + 1; y < boardComponent.BoardSize.Y; y++)
                if (TryGetMatch(boardComponent, itemPosition.X, y, itemType, out EcsEntity match))
                    _matches.Add(match);
                else
                    break;
        }

        private bool TryGetMatch(in BoardComponent boardComponent, int x, int y, int itemType, out EcsEntity match)
        {
            match = EcsEntity.Null;
            
            if (!boardComponent.TryGetBoardItem(new GridPosition(x, y), out EcsEntity item))
                return false;

            if (!item.Has<ItemTypeComponent>())
                return false;

            if (item.Get<ItemTypeComponent>().Value != itemType)
                return false;

            match = item;

            return true;
        }
    }
}