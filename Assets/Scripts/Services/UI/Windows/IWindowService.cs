using App.UI.Windows;
using Cysharp.Threading.Tasks;

namespace App.Services.UI.Windows
{
    public interface IWindowService
    {
        UniTask<IUIWindow> Open(WindowId windowId);
    }
}