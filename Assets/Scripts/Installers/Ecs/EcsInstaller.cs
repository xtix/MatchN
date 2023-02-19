using App.Installers.Ecs.SystemsGroups;
using Leopotam.Ecs;
using Zenject;

namespace App.Installers.Ecs
{
    public class EcsInstaller : Installer<EcsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EcsWorld>().AsSingle();
            GameSystemsInstaller.Install(Container);
        }
    }
}