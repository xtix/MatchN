using Cysharp.Threading.Tasks;

namespace App.Core.Pool.Reinitialize
{
    public class ReinitializableObjectPoolDecorator<TResult, TParam> : IObjectPool<TResult, TParam>
        where TResult : class, IPoolReinitializable
    {
        private readonly IObjectPool<TResult, TParam> _objectPool;

        public ReinitializableObjectPoolDecorator(IObjectPool<TResult, TParam> objectPool)
        {
            _objectPool = objectPool;
        }

        public async UniTask<TResult> GetAsync(TParam param)
        {
            TResult obj = await _objectPool.GetAsync(param);

            obj.OnSpawn();
            
            return obj;
        }

        public bool Return(TResult obj)
        {
            return _objectPool.Return(obj);
        }
    }
}