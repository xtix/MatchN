using UnityEngine.ResourceManagement.AsyncOperations;

namespace App.Core.Assets.Provider
{
    public readonly struct AssetLoadResult<T> where T : class
    {
        public readonly AsyncOperationHandle Handle;
        public readonly T Object;

        public AssetLoadResult(AsyncOperationHandle handle, T obj)
        {
            Handle = handle;
            Object = obj;
        }
    }
}