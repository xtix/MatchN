using App.UI.Windows;
using Cysharp.Threading.Tasks;

namespace App.Services.UI.UIRootProvider
{
    public interface IUIRootProvider
    {
        UIRoot UIRoot { get; }

        UniTask InitializeAsync();
    }
}