using App.UI.Elements.RestartButton;
using Zenject;

namespace App.Installers.UI.Elements
{
    public class RestartButtonControllerInstaller : Installer<RestartButtonControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(RestartButtonController), typeof(IInitializable))
                .To<RestartButtonController>()
                .AsSingle();
        }
    }
}