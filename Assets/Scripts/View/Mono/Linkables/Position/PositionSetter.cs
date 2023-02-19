using App.Ecs.View.Position;
using Leopotam.Ecs;
using UnityEngine;

namespace App.View.Mono.Linkables.Position
{
    public class PositionSetter : MonoLinkableBase, IPositionable
    {
        [SerializeField] private Transform _transform;
        
        public Vector3 Position
        {
            set => _transform.position = value;
        }

        protected override void LinkToEntity()
        {
            if (!Entity.Has<PositionableViewComponent>())
                Entity.Get<PositionableViewComponent>().View = this;
        }
    }
}