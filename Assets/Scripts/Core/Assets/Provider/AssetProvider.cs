using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace App.Core.Assets.Provider
{
    public class AssetProvider : IAssetProvider
    {
        public async UniTask InitializeAsync()
        {
            await Addressables.InitializeAsync();
        }

        public async UniTask<AssetLoadResult<T>> LoadAsync<T>(string address) where T : class
        {
            return await LoadAsync(Addressables.LoadAssetAsync<T>(address));
        }

        public async UniTask<AssetLoadResult<T>> LoadAsync<T>(AssetReference assetReference) where T : class
        {
            return await LoadAsync(Addressables.LoadAssetAsync<T>(assetReference));
        }

        public void Release(AsyncOperationHandle handle)
        {
            Addressables.Release(handle);
        }

        private async UniTask<AssetLoadResult<T>> LoadAsync<T>(AsyncOperationHandle<T> handle) where T : class
        {
            T obj = await handle;

            return new AssetLoadResult<T>(handle, obj);
        }
    }
}