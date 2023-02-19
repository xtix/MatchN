using System.Collections.Generic;
using App.View.Mono.Assets;
using UnityEngine;
using Zenject;

namespace App.UI.Windows
{
    [RequireComponent(typeof(AssetCleaner))]
    public abstract class UIWindowBase : MonoBehaviour, IUIWindow
    {
        private IEnumerable<IController> _controllers;
        
        [Inject]
        public void Construct(IEnumerable<IController> controllers)
        {
            _controllers = controllers;
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}