using App.Core.Assets;
using App.Core.Object;
using App.UI.Hud;
using Zenject;

namespace App.Installers.UI.Hud
{
    public class HudFactoryInstaller : Installer<HudFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectFactory<IHud, string>>()
                .To<AssetFactory<IHud, App.UI.Hud.Hud>>()
                .AsSingle();
        }
    }
}