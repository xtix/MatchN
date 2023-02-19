using App.Constants;
using App.Core.Object;
using App.UI.Windows;
using Cysharp.Threading.Tasks;

namespace App.Services.UI.UIRootProvider
{
    public class UIRootProvider : IUIRootProvider
    {
        private readonly IObjectFactory<UIRoot, string> _objectFactory;

        public UIRoot UIRoot { get; private set; }

        public UIRootProvider(IObjectFactory<UIRoot, string> objectFactory)
        {
            _objectFactory = objectFactory;
        }

        public async UniTask InitializeAsync()
        {
            UIRoot = await _objectFactory.CreateAsync(AssetAddress.UIRoot);
        }
    }
}