using App.Ecs.Board;
using App.Ecs.Board.State;
using App.Ecs.Item.Spawn;
using App.Extensions;
using App.Services.Board.Grid;
using App.Services.Item.Type;
using Leopotam.Ecs;

namespace App.Ecs.Fill
{
    public sealed class BoardFillSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;

        private readonly EcsFilter<BoardComponent, BoardFillStateTag>
            .Exclude<BoardFilledEvent> _boardFilter;

        private readonly IItemTypePicker _itemTypePicker;

        public BoardFillSystem(IItemTypePicker itemTypePicker)
        {
            _itemTypePicker = itemTypePicker;
        }

        public void Run()
        {
            if (_boardFilter.IsEmpty())
                return;
            
            foreach (int i in _boardFilter)
            {
                ref BoardComponent boardComponent = ref _boardFilter.Get1(i);

                for (int x = 0; x < boardComponent.BoardSize.X; x++)
                {
                    var gridPosition = new GridPosition(x, boardComponent.BoardSize.Y - 1);

                    if (!boardComponent.HasItemInPosition(gridPosition))
                        _world.NewEntity().Replace(
                            new SpawnItemRequest(
                                gridPosition,
                                _itemTypePicker.GetItemType(),
                                new GridPosition(gridPosition.X, gridPosition.Y + 1)
                            )
                        );
                }
            }
        }
    }
}