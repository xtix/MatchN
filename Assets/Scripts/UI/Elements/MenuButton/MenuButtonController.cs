using App.Services.UI.Windows;
using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace App.UI.Elements.MenuButton
{
    public class MenuButtonController : IController, IInitializable
    {
        private readonly MenuButtonView _view;
        private readonly IWindowService _windowService;

        public MenuButtonController(MenuButtonView view, IWindowService windowService)
        {
            _view = view;
            _windowService = windowService;
        }

        public void Initialize()
        {
            _view.Button
                .OnClickAsObservable()
                .Subscribe(_ => OnMenuClicked())
                .AddTo(_view);
        }

        private void OnMenuClicked()
        {
            OpenMenuAsync().Forget();
        }

        private async UniTaskVoid OpenMenuAsync()
        {
            await _windowService.Open(WindowId.Menu);
        }
    }
}