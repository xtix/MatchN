using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.UI.Windows.Menu
{
    public class MenuWindow : UIWindowBase, IInitializable
    {
        [SerializeField] private Button _closeButton;

        public void Initialize()
        {
            _closeButton
                .OnClickAsObservable()
                .Subscribe(_ => Close())
                .AddTo(this);
        }
    }
}