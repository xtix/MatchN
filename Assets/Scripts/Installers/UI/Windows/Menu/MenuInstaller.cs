using App.Installers.UI.Elements;
using App.UI;
using App.UI.Elements.RestartButton;
using App.UI.Windows.Menu;
using UnityEngine;
using Zenject;

namespace App.Installers.UI.Windows.Menu
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private RestartButtonView restartButtonView;

        public override void InstallBindings()
        {
            InstallViewBindings();
            InstallControllerBindings();

            InstallMenuBindings();
        }

        private void InstallMenuBindings()
        {
            Container.Bind<IController>()
                .To(
                    typeof(RestartButtonController)
                )
                .FromResolveAll()
                .WhenInjectedInto<MenuWindow>();
        }

        private void InstallControllerBindings()
        {
            RestartButtonControllerInstaller.Install(Container);
        }
        
        private void InstallViewBindings()
        {
            Container.BindInstance(restartButtonView).AsSingle();
        }
    }
}