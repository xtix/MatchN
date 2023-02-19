using App.Core.Random;
using Zenject;

namespace App.Installers.Core
{
    public class RandomInstaller: Installer<RandomInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnityRandom>().AsSingle();
        }
    }
}