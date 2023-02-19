using App.Core.Assets.Provider;
using App.Core.Object;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace App.Core.Assets
{
    public class AssetFactory<TResult, TMono> : IObjectFactory<TResult, string>
        where TMono : MonoBehaviour, TResult
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public AssetFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public async UniTask<TResult> CreateAsync(string assetAddress)
        {
            AssetLoadResult<GameObject> assetLoadResult = await _assetProvider.LoadAsync<GameObject>(assetAddress);

            TMono obj = _instantiator.InstantiatePrefabForComponent<TMono>(assetLoadResult.Object);

            if (obj.TryGetComponent(out IAssetReleasable assetReleasable))
                assetReleasable.SetAsset(assetLoadResult.Handle);

            return obj;
        }
    }
}