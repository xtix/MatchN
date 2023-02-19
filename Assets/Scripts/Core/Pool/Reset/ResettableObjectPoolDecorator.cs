using Cysharp.Threading.Tasks;

namespace App.Core.Pool.Reset
{
    public class ResettableObjectPoolDecorator<TResult, TParam> : IObjectPool<TResult, TParam>
        where TResult : class, IPoolResettable
    {
        private readonly IObjectPool<TResult, TParam> _objectPool;

        public ResettableObjectPoolDecorator(IObjectPool<TResult, TParam> objectPool)
        {
            _objectPool = objectPool;
        }

        public async UniTask<TResult> GetAsync(TParam param)
        {
            return await _objectPool.GetAsync(param);
        }

        public bool Return(TResult obj)
        {
            bool isReturned = _objectPool.Return(obj);
            
            if (isReturned)
                obj.OnDespawn();

            return isReturned;
        }
    }
}