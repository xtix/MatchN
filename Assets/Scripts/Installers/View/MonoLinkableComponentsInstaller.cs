using App.View.Mono.Linkables;
using Zenject;

namespace App.Installers.View
{
    public class MonoLinkableComponentsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MonoLinkableBase>().FromComponentsInChildren();
        }
    }
}