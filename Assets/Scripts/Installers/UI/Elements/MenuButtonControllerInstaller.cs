using App.UI.Elements.MenuButton;
using Zenject;

namespace App.Installers.UI.Elements
{
    public class MenuButtonControllerInstaller : Installer<MenuButtonControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(MenuButtonController), typeof(IInitializable))
                .To<MenuButtonController>()
                .AsSingle();
        }
    }
}