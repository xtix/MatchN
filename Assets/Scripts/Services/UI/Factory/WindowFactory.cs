using App.Core.Assets;
using App.Core.Assets.Provider;
using App.Core.Object;
using App.Services.UI.UIRootProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace App.Services.UI.Factory
{
    public class WindowFactory<TResult, TMono> : IObjectFactory<TResult, AssetReference>
        where TMono : MonoBehaviour, TResult
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly IUIRootProvider _uiRootProvider;

        public WindowFactory(IInstantiator instantiator, IAssetProvider assetProvider, IUIRootProvider uiRootProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
            _uiRootProvider = uiRootProvider;
        }

        public async UniTask<TResult> CreateAsync(AssetReference assetReference)
        {
            AssetLoadResult<GameObject> assetLoadResult = await _assetProvider.LoadAsync<GameObject>(assetReference);

            TMono obj = _instantiator.InstantiatePrefabForComponent<TMono>(assetLoadResult.Object, _uiRootProvider.UIRoot.transform);

            if (obj.TryGetComponent(out IAssetReleasable assetReleasable))
                assetReleasable.SetAsset(assetLoadResult.Handle);

            return obj;
        }
    }
}