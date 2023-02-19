using App.Ecs.Item;
using App.Ecs.Match.Check;
using Leopotam.Ecs;

namespace App.Ecs.Board.State.Transitions
{
    public sealed class InputToMatchTransitionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, InputStateTag> _boardFilter;
        private readonly EcsFilter<ItemTag, CheckMatchRequest> _itemToMatchFilter;

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;

            if (_itemToMatchFilter.IsEmpty())
                return;
            
            foreach (int i in _boardFilter)
            {
                ref EcsEntity entity = ref _boardFilter.GetEntity(i);

                entity.Del<InputStateTag>();
                entity.Get<MatchStateTag>();
            }
        }
    }
}