using System;
using App.Core.Scene;
using App.Installers.Core;
using App.Installers.Services;
using App.Installers.Services.UI;
using App.Installers.UI.Hud;
using App.Services.Game;
using App.Services.Game.States;
using App.Services.SystemComposer;
using UnityEngine;
using Zenject;

namespace App.Installers.Level
{
    public class LevelInstaller: MonoInstaller
    {
        [SerializeField] private Settings _settings;
        
        public override void InstallBindings()
        {
            InstallSettingsBindings();

            WindowServiceInstaller.Install(Container);
            RandomInstaller.Install(Container);
            ItemServicesInstaller.Install(Container);
            GameServicesInstaller.Install(Container);
            HudFactoryInstaller.Install(Container);

            InstallLevelGameStateBindings();
        }

        private void InstallSettingsBindings()
        {
            Container.BindInstance(_settings.Camera).AsSingle();
        }

        private void InstallLevelGameStateBindings()
        {
            Container.Bind<ISystemComposer>()
                .To<GameSystemComposer>()
                .FromResolve()
                .WhenInjectedInto<InitLevelState>();
            Container.BindInterfacesAndSelfTo<InitLevelState>().AsSingle();

            Container.Bind<ISystemComposer>()
                .To<GameSystemComposer>()
                .FromResolve()
                .WhenInjectedInto<GameLoopState>();
            Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();

            Container.Bind<StateBase>()
                .To(
                    typeof(InitLevelState),
                    typeof(GameLoopState)
                )
                .FromResolveAll()
                .WhenInjectedInto<SceneGameStateInjector<StateBase, Game>>();
            Container.BindInterfacesTo<SceneGameStateInjector<StateBase, Game>>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public Camera Camera;
        }
    }
}