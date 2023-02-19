using System.Collections.Generic;
using Zenject;

namespace App.View.Mono.Linkables
{
    public class MonoLinkableEntity : MonoLinkableBase
    {
        private IEnumerable<MonoLinkableBase> _monoLinkableComponents;

        [Inject]
        public void Construct(IEnumerable<MonoLinkableBase> monoLinkableComponents)
        {
            _monoLinkableComponents = monoLinkableComponents;
        }

        protected override void LinkToEntity()
        {
            foreach (MonoLinkableBase component in _monoLinkableComponents)
            {
                if (component is not MonoLinkableEntity)
                    component.Link(Entity);
            }
        }
    }
}