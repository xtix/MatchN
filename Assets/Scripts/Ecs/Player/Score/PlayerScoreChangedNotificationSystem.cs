using App.Core.Reactivity;
using Leopotam.Ecs;

namespace App.Ecs.Player.Score
{
    public sealed class PlayerScoreChangedNotificationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerScoreComponent, PlayerScoreChangedEvent> _filter;

        private readonly IReactiveNotifier<int> _playerScoreChangeReactiveNotifier;

        public PlayerScoreChangedNotificationSystem(IReactiveNotifier<int> playerScoreChangeReactiveNotifier)
        {
            _playerScoreChangeReactiveNotifier = playerScoreChangeReactiveNotifier;
        }

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PlayerScoreComponent playerScoreComponent = ref _filter.Get1(i);

                _playerScoreChangeReactiveNotifier.Notify(playerScoreComponent.Value);
            }
        }
    }
}