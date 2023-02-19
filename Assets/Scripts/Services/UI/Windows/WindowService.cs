using System.Collections.Generic;
using App.Config.Windows;
using App.Core.Object;
using App.UI.Windows;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace App.Services.UI.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IObjectFactory<IUIWindow, AssetReference> _objectFactory;
        private readonly Dictionary<WindowId, Window> _windowsConfig;

        public WindowService(IObjectFactory<IUIWindow, AssetReference> objectFactory, Dictionary<WindowId, Window> windowsConfig)
        {
            _objectFactory = objectFactory;
            _windowsConfig = windowsConfig;
        }

        public async UniTask<IUIWindow> Open(WindowId windowId)
        {
            return await _objectFactory.CreateAsync(
                _windowsConfig[windowId].Asset);
        }
    }
}