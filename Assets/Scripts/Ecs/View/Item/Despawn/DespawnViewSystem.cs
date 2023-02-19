using App.Ecs.Destroy;
using App.Ecs.View.Color;
using Leopotam.Ecs;

namespace App.Ecs.View.Item.Despawn
{
    public sealed class DespawnViewSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<ItemDespawnableViewComponent, ColorComponent, DestroyRequest> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref ItemDespawnableViewComponent viewComponent = ref _filter.Get1(i);
                ref ColorComponent colorComponent = ref _filter.Get2(i);

                viewComponent.View.Despawn(colorComponent.Value);
                entity.Del<ItemDespawnableViewComponent>();
            }
        }
    }
}