using System.Threading;
using App.Config.Item;
using App.Ecs.View.Animation;
using App.Ecs.View.Swap;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace App.View.Mono.Linkables.Swap
{
    public class Swapper : MonoLinkableBase, ISwappable
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

        public async UniTaskVoid MoveAsync(Vector3 to, bool inFront)
        {
            Entity.Get<AnimatedTag>();
            
            float halfSwapAnimationDuration = _itemAnimation.SwapAnimationDuration / 2;
            float zAxisOffsetSwapAnimation = inFront ? -_itemAnimation.ZAxisOffsetSwapAnimation : _itemAnimation.ZAxisOffsetSwapAnimation;

            await (
                _transform
                    .DOMoveX(to.x, _itemAnimation.SwapAnimationDuration)
                    .SetEase(Ease.OutQuad)
                    .SetLink(gameObject)
                    .WithCancellation(_destroyCancellationToken),
                _transform
                    .DOMoveY(to.y, _itemAnimation.SwapAnimationDuration)
                    .SetEase(Ease.OutQuad)
                    .SetLink(gameObject)
                    .WithCancellation(_destroyCancellationToken),
                DOTween.Sequence()
                    .Append(_transform.DOMoveZ(to.z + zAxisOffsetSwapAnimation, halfSwapAnimationDuration)
                        .SetEase(Ease.Linear))
                    .Append(_transform.DOMoveZ(to.z, halfSwapAnimationDuration)
                        .SetEase(Ease.Linear))
                    .SetLink(gameObject)
                    .WithCancellation(_destroyCancellationToken)
            );

            if (_destroyCancellationToken.IsCancellationRequested)
                return;

            Entity.Del<AnimatedTag>();
        }

        protected override void LinkToEntity()
        {
            if (!Entity.Has<SwappableViewComponent>())
                Entity.Get<SwappableViewComponent>().View = this;
        }
    }
}