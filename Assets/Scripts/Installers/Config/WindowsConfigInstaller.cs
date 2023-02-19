using App.Config.Windows;
using UnityEngine;
using Zenject;

namespace App.Installers.Config
{
    [CreateAssetMenu(menuName = "Game/Installers/Config/" + nameof(WindowsConfigInstaller), fileName = nameof(WindowsConfigInstaller))]
    public class WindowsConfigInstaller : ScriptableObjectInstaller<WindowsConfigInstaller>
    {
        [SerializeField] private WindowsConfig _windowsConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_windowsConfig).IfNotBound();
        }
    }
}