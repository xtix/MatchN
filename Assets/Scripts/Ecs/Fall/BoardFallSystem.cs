using App.Ecs.Board;
using App.Ecs.Board.State;
using App.Ecs.Load;
using App.Ecs.View.Animation;
using App.Extensions;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.Fall
{
    public sealed class BoardFallSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, BoardFillStateTag> _boardFilter;

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;

            foreach (int i in _boardFilter)
            {
                ref BoardComponent boardComponent = ref _boardFilter.Get1(i);

                for (int x = 0; x < boardComponent.BoardSize.X; x++)
                {
                    for (int y = 1; y < boardComponent.BoardSize.Y; y++)
                    {
                        ref EcsEntity item = ref boardComponent.ItemsLookupTable[x, y];
                        
                        if (!item.IsWorldAlive())
                            continue;

                        if (boardComponent.HasItemInPosition(x, y-1))
                            continue;
                        
                        if (item.Has<AnimatedTag>() || item.Has<EntityLoadingTag>())
                            continue;

                        GridPosition newPosition = new GridPosition(x, y - 1);
                        boardComponent.SetItemPositionOnBoard(item, newPosition);
                        item.Get<FallEvent>();
                        
                        boardComponent.ItemsLookupTable[x, y] = EcsEntity.Null;
                    }
                }
            }
        }
    }
}