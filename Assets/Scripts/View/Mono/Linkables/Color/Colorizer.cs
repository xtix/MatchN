using App.Constants;
using App.Ecs.View.Color;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace App.View.Mono.Linkables.Color
{
    public class Colorizer : MonoLinkableBase, IColorizable
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private MaterialPropertyBlock _materialPropertyBlock;
        
        [Inject]
        public void Construct()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
        }

        public void Colorize(UnityEngine.Color color)
        {
            _meshRenderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetColor(ShaderKey.MainColor, color);
            _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        }

        protected override void LinkToEntity()
        {
            if (!Entity.Has<ColorizableViewComponent>())
                Entity.Get<ColorizableViewComponent>().View = this;
        }
    }
}