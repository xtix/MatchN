using App.Core.Pool;
using App.View;
using Cysharp.Threading.Tasks;

namespace App.Services.Spawner
{
    public class PoolableObjectSpawner<T> : ISpawner<T>
        where T : IDespawnObservable<T>
    {
        private readonly IObjectPool<T, string> _objectPool;
        private readonly string _assetAddress;

        public PoolableObjectSpawner(IObjectPool<T, string> objectPool, string assetAddress)
        {
            _objectPool = objectPool;
            _assetAddress = assetAddress;
        }

        public async UniTask<T> SpawnAsync()
        {
            T obj = await _objectPool.GetAsync(_assetAddress);
            obj.Despawned += OnDespawn;
            
            return obj;
        }

        private void OnDespawn(T obj)
        {
            obj.Despawned -= OnDespawn;
            _objectPool.Return(obj);
        }
    }
}