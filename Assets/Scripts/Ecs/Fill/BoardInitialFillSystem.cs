using App.Ecs.Board;
using App.Ecs.Item.Spawn;
using App.Extensions;
using App.Services.Board.Grid;
using App.Services.Item.Type;
using Leopotam.Ecs;

namespace App.Ecs.Fill
{
    public class BoardInitialFillSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<BoardComponent> _boardFilter;

        private readonly IItemTypePicker _itemTypePicker;

        public BoardInitialFillSystem(IItemTypePicker itemTypePicker)
        {
            _itemTypePicker = itemTypePicker;
        }

        public void Init()
        {
            foreach (int index in _boardFilter)
            {
                ref EcsEntity board = ref _boardFilter.GetEntity(index);
                ref BoardComponent boardComponent = ref _boardFilter.Get1(index);

                for (int x = 0; x < boardComponent.BoardSize.X; x++)
                {
                    for (int y = 0; y < boardComponent.BoardSize.Y; y++)
                    {
                        var gridPosition = new GridPosition(x, y);

                        if (boardComponent.HasItemInPosition(gridPosition))
                            continue;

                        _world.NewEntity().Replace(
                            new SpawnItemRequest(
                                gridPosition,
                                _itemTypePicker.GetItemType(),
                                gridPosition
                            )
                        );
                    }
                }

                board.Get<BoardFilledEvent>();
            }
        }
    }
}