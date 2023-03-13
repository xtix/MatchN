using App.Ecs.Board;
using App.Ecs.Board.Grid;
using App.Ecs.Item;
using App.Services.Board;
using App.Services.Board.Grid;
using Leopotam.Ecs;

namespace Tests.TestHelpers.Builders
{
    public class BoardBuilder
    {
        private readonly EcsWorld _world;

        private BoardSize _boardSize;
        private int?[,] _itemTypes;

        public BoardBuilder(EcsWorld world)
        {
            _world = world;
        }

        public BoardBuilder WithSize(int x, int y)
        {
            _boardSize = new BoardSize(x, y);
            return this;
        }

        public BoardBuilder WithItems(int?[,] itemTypes)
        {
            _itemTypes = itemTypes;
            return this;
        }

        public EcsEntity Build()
        {
            BoardComponent boardComponent = new BoardComponent(_boardSize);

            EcsEntity entity = _world.NewEntity();
            entity.Replace(boardComponent);

            if (_itemTypes != null)
                BuildItems(boardComponent);

            return entity;
        }

        private void BuildItems(in BoardComponent boardComponent)
        {
            for (int x = 0; x < _boardSize.X; x++)
            {
                for (int y = 0; y < _boardSize.Y; y++)
                {
                    if (_itemTypes[x, y] is { } itemType)
                    {
                        EcsEntity item = _world.NewEntity();
                        item.Get<ItemTag>();
                        item.Replace(new ItemTypeComponent(itemType));
                        item.Get<PositionOnBoardComponent>().Value = new GridPosition(x, y);

                        boardComponent.ItemsLookupTable[x, y] = item;
                    }
                }
            }
        }
    }
}