using UnityEngine.ResourceManagement.AsyncOperations;

namespace App.Core.Assets
{
    public interface IAssetReleasable
    {
        void SetAsset(AsyncOperationHandle handle);
    }
}