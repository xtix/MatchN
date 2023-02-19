using App.Ecs.Destroy;
using App.Ecs.Match;
using Leopotam.Ecs;

namespace App.Ecs.Item.Destroy
{
    public sealed class RequestDestroyMatchedItemSystem: IEcsRunSystem
    {
        private readonly EcsFilter<ItemTag, MatchedEvent> _matchedItemFilter;

        public void Run()
        {
            foreach (int i in _matchedItemFilter)
            {
                ref EcsEntity entity = ref _matchedItemFilter.GetEntity(i);
                entity.Get<DestroyRequest>();
            }
        }
    }
}