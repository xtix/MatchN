using System;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace App.Core.Scene
{
    public interface ISceneLoader
    {
        UniTask<SceneInstance> LoadAsync(string name, IProgress<float> progress = null);
    }
}