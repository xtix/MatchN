using System;
using System.Collections.Generic;
using App.Core.Object;
using Cysharp.Threading.Tasks;

namespace App.Core.Pool
{
    public class ObjectPool<TResult, TParam> : IObjectPool<TResult, TParam>
        where TResult : class
    {
        private readonly IObjectFactory<TResult, TParam> _objectFactory;
        private readonly int _capacity;
        private readonly Stack<TResult> _pool;

        public ObjectPool(IObjectFactory<TResult, TParam> objectFactory,  int capacity)
        {
            _objectFactory = objectFactory;
            _capacity = capacity;
            _pool = new Stack<TResult>(capacity);
        }

        public async UniTask<TResult> GetAsync(TParam param)
        {
            if (!_pool.TryPop(out TResult obj))
                obj = await _objectFactory.CreateAsync(param);

            return obj;
        }

        public bool Return(TResult obj)
        {
            if (_pool.Contains(obj))
                throw new ArgumentException($"Returned object ${typeof(TResult)} already in pool ${GetType()}");

            if (_pool.Count >= _capacity)
                return false;

            _pool.Push(obj);

            return true;
        }
    }
}