using App.Services.Input;
using App.Services.Input.Controls;
using Zenject;

namespace App.Installers.Services
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Controls>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }
    }
}