using App.Ecs.Item;
using App.Ecs.Match.Check;
using App.Ecs.View.Animation;
using Leopotam.Ecs;

namespace App.Ecs.Board.State.Transitions
{
    public sealed class MatchToBoardFillTransitionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, MatchStateTag> _boardFilter;
        private readonly EcsFilter<ItemTag, CheckMatchRequest> _itemToMatchFilter;
        private readonly EcsFilter<ItemTag, AnimatedTag> _animatedItemFilter;
        private readonly EcsFilter<ItemTag> _itemFilter;

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;
            
            if (!_itemToMatchFilter.IsEmpty())
                return;

            if (!_animatedItemFilter.IsEmpty())
                return;

            foreach (int i in _boardFilter)
            {
                ref BoardComponent boardComponent = ref _boardFilter.Get1(i);

                if (_itemFilter.GetEntitiesCount() >= boardComponent.BoardSize.Square())
                    return;
                
                ref EcsEntity entity = ref _boardFilter.GetEntity(i);

                entity.Del<MatchStateTag>();
                entity.Get<BoardFillStateTag>();
            }
        }
    }
}