using System;
using App.View.Mono.Assets;
using App.View.Mono.Linkables.Item.Despawn;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace App.View.Mono.Linkables.Item
{
    [RequireComponent(typeof(AssetCleaner))]
    public class ItemView : MonoLinkableEntity,
        IInitializable,
        IDisposable,
        IItemView
    {
        private static readonly Vector3 InitialPosition  = new(10000, 10000, 10000);

        public event Action<IItemView> Despawned;

        [SerializeField] private ItemDespawner _itemDespawner;

        [SerializeField] private Transform _transform;
        [SerializeField] private MeshRenderer _meshRenderer;

        public void Initialize()
        {
            _itemDespawner.Despawned += RaiseDespawnedEvent;
        }

        public void Dispose()
        {
            _itemDespawner.Despawned -= RaiseDespawnedEvent;
        }

        public void OnSpawn()
        {
            _meshRenderer.enabled = true;
            gameObject.SetActive(true);
            ResetTransform();
        }

        public void OnDespawn()
        {
            Entity = EcsEntity.Null;
            gameObject.SetActive(false);
            ResetTransform();
        }

        public void Destruct()
        {
            Destroy(gameObject);
        }

        private void ResetTransform()
        {
            _transform.SetPositionAndRotation(InitialPosition, Quaternion.identity);
        }

        private void RaiseDespawnedEvent()
        {
            Despawned?.Invoke(this);
        }
    }
}