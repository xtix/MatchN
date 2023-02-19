using System.Linq;
using App.Config.Windows;
using App.Core.Assets;
using App.Core.Object;
using App.Services.UI.Factory;
using App.Services.UI.UIRootProvider;
using App.Services.UI.Windows;
using App.UI.Windows;
using UnityEngine.AddressableAssets;
using Zenject;

namespace App.Installers.Services.UI
{
    public class WindowServiceInstaller : Installer<WindowServiceInstaller>
    {
        [Inject] private WindowsConfig _windowsConfig;
        
        public override void InstallBindings()
        {
            InstallUIRootProviderBindings();
            InstallWindowFactoryBindings();

            Container.BindInstance(_windowsConfig.WindowList.ToDictionary(x => x.WindowId, x => x))
                .WhenInjectedInto<WindowService>();
            Container.BindInterfacesTo<WindowService>().AsSingle();
        }

        private void InstallUIRootProviderBindings()
        {
            Container.Bind<IObjectFactory<UIRoot, string>>()
                .To<AssetFactory<UIRoot, UIRoot>>()
                .AsSingle();
            Container.BindInterfacesTo<UIRootProvider>().AsSingle();
        }

        private void InstallWindowFactoryBindings()
        {
            Container.Bind<IObjectFactory<IUIWindow, AssetReference>>()
                .To<WindowFactory<IUIWindow, UIWindowBase>>()
                .AsSingle();
        }
    }
}