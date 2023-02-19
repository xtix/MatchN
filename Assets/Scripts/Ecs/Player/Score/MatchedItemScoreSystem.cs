using App.Ecs.Item;
using App.Ecs.Match;
using Leopotam.Ecs;

namespace App.Ecs.Player.Score
{
    public sealed class MatchedItemScoreSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemTag, MatchedEvent> _matchedItemFilter;
        private readonly EcsFilter<PlayerScoreComponent> _playerScoreFilter;

        public void Run()
        {
            foreach (int _ in _matchedItemFilter)
            {
                foreach (int j in _playerScoreFilter)
                {
                    ref EcsEntity entity = ref _playerScoreFilter.GetEntity(j);
                    _playerScoreFilter.Get1(j).Value++;
                    entity.Get<PlayerScoreChangedEvent>();
                }
            }
        }
    }
}