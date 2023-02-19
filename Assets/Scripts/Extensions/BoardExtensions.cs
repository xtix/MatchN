using App.Ecs.Board;
using App.Ecs.Board.Grid;
using App.Ecs.Item;
using App.Services.Board.Grid;
using Leopotam.Ecs;
using UnityEngine;

namespace App.Extensions
{
    public static class BoardExtensions
    {
        public static bool HasItemInPosition(in this BoardComponent boardComponent, GridPosition gridPosition)
        {
            return boardComponent.HasItemInPosition(gridPosition.X, gridPosition.Y);
        }

        public static bool HasItemInPosition(in this BoardComponent boardComponent, int x, int y)
        {
            return boardComponent.ItemsLookupTable[x, y] != EcsEntity.Null;
        }

        public static void SetItemPositionOnBoard(
            in this BoardComponent boardComponent,
            in EcsEntity item,
            GridPosition gridPosition
        ) {
            item.Get<PositionOnBoardComponent>().Value = gridPosition;
            boardComponent.ItemsLookupTable[gridPosition.X, gridPosition.Y] = item;
            item.Get<PositionOnBoardChangedEvent>();
        }

        public static bool IsPositionInBoardBounds(in this BoardComponent boardComponent, GridPosition gridPosition)
        {
            return gridPosition.X >= 0 && gridPosition.X < boardComponent.BoardSize.X
                && gridPosition.Y >= 0 && gridPosition.Y < boardComponent.BoardSize.Y;
        }

        public static bool TryGetBoardItem(
            in this BoardComponent boardComponent,
            GridPosition gridPosition,
            out EcsEntity item
        ) {
            item = EcsEntity.Null;

            if (!boardComponent.IsPositionInBoardBounds(gridPosition))
                return false;

            ref EcsEntity entity = ref boardComponent.ItemsLookupTable[gridPosition.X, gridPosition.Y];

            if (!entity.IsWorldAlive())
                return false;

            if (!entity.Has<ItemTag>())
                return false;

            item = entity;

            return true;
        }

        public static bool TryGetAdjacentItemPositionToSwap(
            in this BoardComponent boardComponent,
            GridPosition targetGridPosition,
            GridPosition pointerItemPosition,
            out GridPosition adjacentItemPosition
        ) {
            adjacentItemPosition = new GridPosition();
            GridPosition position = pointerItemPosition - targetGridPosition;

            if (position.X == position.Y)
                return false;

            var adjacentPosition = new GridPosition(
                Mathf.Abs(position.X) > Mathf.Abs(position.Y) ? position.X / Mathf.Abs(position.X) : 0,
                Mathf.Abs(position.Y) > Mathf.Abs(position.X) ? position.Y / Mathf.Abs(position.Y) : 0
            ) + targetGridPosition;

            if (!boardComponent.IsPositionInBoardBounds(adjacentPosition))
                return false;

            adjacentItemPosition = adjacentPosition;
            
            return true;
        }
    }
}