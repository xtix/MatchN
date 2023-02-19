using System;
using App.Services.UI.Windows;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace App.Config.Windows
{
    [Serializable]
    public class Window
    {
        [SerializeField] private WindowId _windowId;
        [SerializeField] private AssetReference _asset;

        public WindowId WindowId => _windowId;
        public AssetReference Asset => _asset;
    }
}