using App.Core.Object;
using Cysharp.Threading.Tasks;

namespace App.Core.Pool.Destruct
{
    public class DestructibleObjectPoolDecorator<TResult, TParam> : IObjectPool<TResult, TParam>
        where TResult : class, IDestructible
    {
        private readonly IObjectPool<TResult, TParam> _objectPool;

        public DestructibleObjectPoolDecorator(IObjectPool<TResult, TParam> objectPool)
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
            
            if (!isReturned)
                obj.Destruct();

            return isReturned;
        }
    }
}