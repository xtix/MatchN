using App.Services.Game;
using UniRx;
using Zenject;

namespace App.UI.Elements.RestartButton
{
    public class RestartButtonController : IController, IInitializable
    {
        private readonly RestartButtonView _buttonView;
        private readonly IGame _game;

        public RestartButtonController(IGame game, RestartButtonView buttonView)
        {
            _game = game;
            _buttonView = buttonView;
        }

        public void Initialize()
        {
            _buttonView.Button
                .OnClickAsObservable()
                .Subscribe(_ => OnRestartClicked())
                .AddTo(_buttonView);
        }

        private void OnRestartClicked()
        {
            _game.Restart();
        }
    }
}