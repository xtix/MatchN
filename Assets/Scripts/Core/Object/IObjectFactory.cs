using Cysharp.Threading.Tasks;

namespace App.Core.Object
{
    public interface IObjectFactory<TResult, in TParam>
    {
        UniTask<TResult> CreateAsync(TParam param);
    }
}