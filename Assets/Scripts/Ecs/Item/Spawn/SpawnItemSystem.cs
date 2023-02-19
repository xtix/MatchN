using App.Ecs.Board;
using App.Ecs.Board.State;
using App.Ecs.Load;
using App.Ecs.Spawn;
using App.Ecs.View.Color;
using App.Extensions;
using App.Services.Item.ColorGenerator;
using App.Services.Spawner;
using App.View.Mono.Linkables.Item;
using Cysharp.Threading.Tasks;
using Leopotam.Ecs;

namespace App.Ecs.Item.Spawn
{
    public sealed class SpawnItemSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        
        private readonly EcsFilter<BoardComponent, BoardFillStateTag> _boardFilter;
        private readonly EcsFilter<SpawnItemRequest> _spawnRequestFilter;

        private readonly ISpawner<IItemView> _spawner;
        private readonly IItemColorGenerator _itemColorGenerator;

        public SpawnItemSystem(ISpawner<IItemView> spawner, IItemColorGenerator itemColorGenerator)
        {
            _spawner = spawner;
            _itemColorGenerator = itemColorGenerator;
        }

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;

            foreach (int i in _boardFilter)
            {
                EcsComponentRef<BoardComponent> boardComponentRef = _boardFilter.Get1Ref(i);

                foreach (int j in _spawnRequestFilter)
                {
                    ref EcsEntity entity = ref _spawnRequestFilter.GetEntity(j);
                    ref SpawnItemRequest spawnItemRequest = ref _spawnRequestFilter.Get1(j);

                    SpawnItemAsync(spawnItemRequest, boardComponentRef).Forget();

                    entity.Del<SpawnItemRequest>();
                }
            }
        }

        private async UniTaskVoid SpawnItemAsync(
            SpawnItemRequest spawnItemRequest,
            EcsComponentRef<BoardComponent> boardComponentRef
        ) {
            int itemType = spawnItemRequest.ItemType;

            EcsEntity entity = _world.NewEntity();
            entity.Get<EntityLoadingTag>();
            entity.Replace(new ItemTypeComponent(itemType));
            entity.Get<ItemTag>();
            boardComponentRef.Unref().SetItemPositionOnBoard(entity, spawnItemRequest.GridPosition);
            entity.Get<ColorComponent>().Value = _itemColorGenerator.GenerateColor(itemType);
            entity.Replace(new SpawnPositionComponent(spawnItemRequest.SpawnGridPosition));

            IItemView itemView = await _spawner.SpawnAsync();
            itemView.Link(entity);

            entity.Del<EntityLoadingTag>();
            entity.Get<EntityLoadedEvent>();
        }
    }
}