using System;
using UnityEngine;

namespace App.Config.Item
{
    [Serializable]
    public class ItemAnimation
    {
        [SerializeField] private float _fallAnimationDuration;
        [SerializeField] private float _swapAnimationDuration;
        [SerializeField] private float _zAxisOffsetSwapAnimation;

        public float FallAnimationDuration => _fallAnimationDuration;
        public float SwapAnimationDuration => _swapAnimationDuration;
        public float ZAxisOffsetSwapAnimation => _zAxisOffsetSwapAnimation;
    }
}