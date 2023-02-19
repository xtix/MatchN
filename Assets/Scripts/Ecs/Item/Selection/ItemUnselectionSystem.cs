using App.Ecs.Input.Click;
using App.Ecs.Input.ClickReleased;
using Leopotam.Ecs;

namespace App.Ecs.Item.Selection
{
    public sealed class ItemUnselectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ClickEvent> _clickEventFilter;
        private readonly EcsFilter<ClickReleasedEvent> _clickReleasedEventFilter;
        private readonly EcsFilter<ItemTag, SelectedTag> _selectedItemFilter;

        public void Run()
        {
            if (_clickEventFilter.IsEmpty() && _clickReleasedEventFilter.IsEmpty())
                return;
            
            foreach (int k in _selectedItemFilter)
            {
                ref EcsEntity entity = ref _selectedItemFilter.GetEntity(k);
                entity.Del<SelectedTag>();
            }
        }
    }
}