using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace App.Core.Assets.Provider
{
    public interface IAssetProvider
    {
        UniTask InitializeAsync();

        UniTask<AssetLoadResult<T>> LoadAsync<T>(string address) where T : class;

        UniTask<AssetLoadResult<T>> LoadAsync<T>(AssetReference assetReference) where T : class;

        void Release(AsyncOperationHandle handle);
    }
}