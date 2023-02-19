using App.Core.Assets.Provider;
using App.Core.Scene;
using App.Core.StateMachine;
using App.Installers.Services;
using App.Services.Game;
using App.Services.Game.States;
using Zenject;

namespace App.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AssetProvider>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            InputInstaller.Install(Container);

            InstallStateMachineBindings();
            Container.BindInterfacesAndSelfTo<Game>().AsSingle();
        }

        private void InstallStateMachineBindings()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();

            Container.Bind<StateBase>()
                .To(
                    typeof(BootstrapState),
                    typeof(LoadLevelState)
                )
                .FromResolveAll()
                .WhenInjectedInto<StateMachine<StateBase, Game>>();
            Container.BindInterfacesTo<StateMachine<StateBase, Game>>().AsSingle();
        }
    }
}