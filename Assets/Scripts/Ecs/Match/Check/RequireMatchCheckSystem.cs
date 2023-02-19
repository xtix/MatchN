using App.Ecs.Board.Grid;
using App.Ecs.Item;
using Leopotam.Ecs;

namespace App.Ecs.Match.Check
{
    public sealed class RequireMatchCheckSystem: IEcsRunSystem
    {
        private readonly EcsFilter<PositionOnBoardComponent, ItemTypeComponent, ItemTag, PositionOnBoardChangedEvent> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity item = ref _filter.GetEntity(i);
                item.Get<CheckMatchRequest>();
            }
        }
    }
}