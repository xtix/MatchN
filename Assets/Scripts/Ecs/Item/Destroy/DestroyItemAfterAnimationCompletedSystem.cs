using App.Ecs.Board;
using App.Ecs.Board.Grid;
using App.Ecs.Destroy;
using App.Ecs.View.Animation;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace App.Ecs.Item.Destroy
{
    public sealed class DestroyItemAfterAnimationCompletedSystem: IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent> _boardFilter;
        private readonly EcsFilter<PositionOnBoardComponent, ItemTag, DestroyRequest>
            .Exclude<AnimatedTag> _despawnedItemFilter;

        public void Run()
        {
            foreach (int i in _boardFilter)
            {
                ref BoardComponent boardComponent = ref _boardFilter.Get1(i);

                foreach (int j in _despawnedItemFilter)
                {
                    GridPosition gridPosition = _despawnedItemFilter.Get1(j).Value;
                    boardComponent.ItemsLookupTable[gridPosition.X, gridPosition.Y] = EcsEntity.Null;

                    ref EcsEntity entity = ref _despawnedItemFilter.GetEntity(j);
                    entity.Destroy();
                }
            }
        }
    }
}