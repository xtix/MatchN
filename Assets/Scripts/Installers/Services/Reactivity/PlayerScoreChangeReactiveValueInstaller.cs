using App.Core.Reactivity;
using Zenject;

namespace App.Installers.Services.Reactivity
{
    public class PlayerScoreChangeReactiveValueInstaller : Installer<PlayerScoreChangeReactiveValueInstaller>
    {
        public const string PlayerScoreChangeReactiveValueServiceId = "PlayerScoreChangeReactiveValue";

        public override void InstallBindings()
        {
            Container.Bind<ReactiveValue<int>>()
                .WithId(PlayerScoreChangeReactiveValueServiceId)
                .AsCached();
        }
    }
}