using System.Threading;
using App.Config.Item;
using App.Ecs.View.Animation;
using App.Ecs.View.Fall;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace App.View.Mono.Linkables.Fall
{
    public class Fall : MonoLinkableBase, IFallable
    {
        [SerializeField] private Transform _transform;
        
        private ItemAnimation _itemAnimation;
        private CancellationToken _destroyCancellationToken;
        
        [Inject]
        public void Construct(ItemAnimation itemAnimation)
        {
            _itemAnimation = itemAnimation;
            _destroyCancellationToken = this.GetCancellationTokenOnDestroy();
        }

        public async UniTaskVoid FallAsync(Vector3 to)
        {
            Entity.Get<AnimatedTag>();
            await _transform
                .DOMove(to, _itemAnimation.FallAnimationDuration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .WithCancellation(_destroyCancellationToken);

            if (_destroyCancellationToken.IsCancellationRequested)
                return;

            Entity.Del<AnimatedTag>();
        }

        protected override void LinkToEntity()
        {
            if (!Entity.Has<FallableViewComponent>())
                Entity.Get<FallableViewComponent>().View = this;
        }
    }
}