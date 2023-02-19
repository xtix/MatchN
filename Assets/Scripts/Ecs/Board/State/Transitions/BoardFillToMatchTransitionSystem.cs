using App.Ecs.Item;
using App.Ecs.Load;
using App.Ecs.View.Animation;
using Leopotam.Ecs;

namespace App.Ecs.Board.State.Transitions
{
    public sealed class BoardFillToMatchTransitionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BoardComponent, BoardFillStateTag> _boardFilter;
        private readonly EcsFilter<ItemTag, EntityLoadingTag> _loadingItemFilter;
        private readonly EcsFilter<ItemTag, AnimatedTag> _animatedItemFilter;

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;
            
            if (!_loadingItemFilter.IsEmpty() || !_animatedItemFilter.IsEmpty())
                return;
            
            foreach (int i in _boardFilter)
            {
                ref EcsEntity entity = ref _boardFilter.GetEntity(i);

                entity.Del<BoardFillStateTag>();
                entity.Get<MatchStateTag>();
            }
        }
    }
}