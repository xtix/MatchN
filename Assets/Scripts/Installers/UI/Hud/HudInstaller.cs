using App.Installers.UI.Elements;
using App.UI;
using App.UI.Elements.MenuButton;
using App.UI.Elements.PlayerScore;
using UnityEngine;
using Zenject;

namespace App.Installers.UI.Hud
{
    public class HudInstaller : MonoInstaller
    {
        [SerializeField] private PlayerScoreView _playerScoreView;
        [SerializeField] private MenuButtonView _menuButtonView;

        public override void InstallBindings()
        {
            InstallViewBindings();
            InstallControllerBindings();

            InstallHudBindings();
        }

        private void InstallHudBindings()
        {
            Container.Bind<IController>()
                .To(
                    typeof(PlayerScoreController),
                    typeof(MenuButtonController)
                )
                .FromResolveAll()
                .WhenInjectedInto<App.UI.Hud.Hud>();
        }

        private void InstallControllerBindings()
        {
            MenuButtonControllerInstaller.Install(Container);
            PlayerScoreControllerInstaller.Install(Container);
        }

        private void InstallViewBindings()
        {
            Container.BindInstance(_menuButtonView).AsSingle();
            Container.BindInstance(_playerScoreView).AsSingle();
        }
    }
}