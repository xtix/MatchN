using App.Core.Reactivity;
using UniRx;
using Zenject;

namespace App.UI.Elements.PlayerScore
{
    public class PlayerScoreController : IController, IInitializable
    {
        private readonly PlayerScoreView _view;
        private readonly IReactiveObservable<int> _playerScoreChangeObservable;

        public PlayerScoreController(PlayerScoreView view, IReactiveObservable<int> playerScoreChangeObservable)
        {
            _view = view;
            _playerScoreChangeObservable = playerScoreChangeObservable;
        }

        public void Initialize()
        {
            _playerScoreChangeObservable.Observable
                .Subscribe(value => _view.SetScore(value))
                .AddTo(_view);
        }
    }
}