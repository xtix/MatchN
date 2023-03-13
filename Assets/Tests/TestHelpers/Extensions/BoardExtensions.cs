using System;
using App.Ecs.Board;
using App.Ecs.Item;
using App.Services.Board;
using Leopotam.Ecs;

namespace Tests.TestHelpers.Extensions
{
    public static class BoardExtensions
    {
        public static int?[,] ToItemTypeArray(in this BoardComponent boardComponent, Func<EcsEntity, bool> filter = null)
        {
            BoardSize boardSize = boardComponent.BoardSize;
            int?[,] itemTypes = new int?[boardSize.X, boardSize.Y];

            for (int x = 0; x < boardSize.X; x++)
            {
                for (int y = 0; y < boardSize.Y; y++)
                {
                    EcsEntity item = boardComponent.ItemsLookupTable[x, y];

                    itemTypes[x, y] = item != EcsEntity.Null && (filter?.Invoke(item) ?? true)
                        ? item.Get<ItemTypeComponent>().Value
                        : null;
                }
            }

            return itemTypes;
        }
    }
}