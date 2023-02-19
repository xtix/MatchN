using App.Installers.Ecs;
using App.Installers.Services.Reactivity;
using App.Services.Board;
using App.Services.Camera;
using Zenject;

namespace App.Installers.Services
{
    public class GameServicesInstaller : Installer<GameServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CameraService>().AsSingle();
            Container.BindInterfacesTo<BoardService>().AsSingle();
            InstallReactiveBindings();

            EcsInstaller.Install(Container);
        }

        private void InstallReactiveBindings()
        {
            PlayerScoreChangeReactiveValueInstaller.Install(Container);
        }
    }
}