using System;
using App.Ecs.View.Animation;
using App.Ecs.View.Item.Despawn;
using App.View.Mono.Particles;
using Leopotam.Ecs;
using UnityEngine;

namespace App.View.Mono.Linkables.Item.Despawn
{
    public class ItemDespawner : MonoLinkableBase, IItemDespawnable
    {
        public event Action Despawned;

        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private ParticleSystem _destroyVfx;
        [SerializeField] private ParticleSystemStoppedEventNotifier _despawnAnimationStoppedEventNotifier;
        
        public void Despawn(UnityEngine.Color color)
        {
            Entity.Get<AnimatedTag>();
            
            _meshRenderer.enabled = false;

            var particlesMain = _destroyVfx.main;
            particlesMain.startColor = new ParticleSystem.MinMaxGradient(color);
            _despawnAnimationStoppedEventNotifier.ParticleSystemSopped += OnDespawnAnimationStopped;

            _destroyVfx.Play();
        }

        protected override void LinkToEntity()
        {
            if (!Entity.Has<ItemDespawnableViewComponent>())
                Entity.Get<ItemDespawnableViewComponent>().View = this;
        }

        private void OnDespawnAnimationStopped()
        {
            _despawnAnimationStoppedEventNotifier.ParticleSystemSopped -= OnDespawnAnimationStopped;

            Entity.Del<AnimatedTag>();
            Despawned?.Invoke();
        }
    }
}