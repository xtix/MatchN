using App.Ecs.Load;
using Leopotam.Ecs;

namespace App.Ecs.View.Color
{
    public sealed class RenderColorWhenEntityLoadedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ColorizableViewComponent, ColorComponent, EntityLoadedEvent> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref ColorizableViewComponent viewComponent = ref _filter.Get1(i);
                ref ColorComponent colorComponent = ref _filter.Get2(i);
                
                viewComponent.View.Colorize(colorComponent.Value);
            }
        }
    }
}