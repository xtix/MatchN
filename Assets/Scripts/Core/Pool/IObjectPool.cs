using Cysharp.Threading.Tasks;

namespace App.Core.Pool
{
    public interface IObjectPool<TResult, in TParam>
    {
        UniTask<TResult> GetAsync(TParam param);

        bool Return(TResult obj);
    }
}