using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace App.Core.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask<SceneInstance> LoadAsync(string name, IProgress<float> progress = null)
        {
            return await Addressables.LoadSceneAsync(name).ToUniTask(progress);
        }
    }
}