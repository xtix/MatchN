using Leopotam.Ecs;
using UnityEngine;

namespace App.View.Mono.Linkables
{
    public abstract class MonoLinkableBase : MonoBehaviour, IView
    {
        protected EcsEntity Entity;

        public virtual void Link(in EcsEntity entity)
        {
            Entity = entity;
            LinkToEntity();
        }

        protected abstract void LinkToEntity();
    }
}