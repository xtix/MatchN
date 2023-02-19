using App.Core.Reactivity;
using App.Installers.Services.Reactivity;
using App.UI.Elements.PlayerScore;
using Zenject;

namespace App.Installers.UI.Elements
{
    public class PlayerScoreControllerInstaller : Installer<PlayerScoreControllerInstaller>
    {
        [Inject(Id = PlayerScoreChangeReactiveValueInstaller.PlayerScoreChangeReactiveValueServiceId)]
        private ReactiveValue<int> _playerScoreChangeReactiveValue;

        public override void InstallBindings()
        {
            Container.Bind<IReactiveObservable<int>>()
                .FromInstance(_playerScoreChangeReactiveValue)
                .WhenInjectedInto<PlayerScoreController>();
            Container
                .Bind(typeof(PlayerScoreController), typeof(IInitializable))
                .To<PlayerScoreController>()
                .AsSingle();
        }
    }
}