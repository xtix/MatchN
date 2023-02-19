using App.Services.Board.Grid;

namespace App.Ecs.Item.Spawn
{
    public readonly struct SpawnItemRequest
    {
        public readonly GridPosition GridPosition;
        public readonly int ItemType;
        public readonly GridPosition SpawnGridPosition;

        public SpawnItemRequest(GridPosition gridPosition, int itemType, GridPosition spawnGridPosition)
        {
            GridPosition = gridPosition;
            ItemType = itemType;
            SpawnGridPosition = spawnGridPosition;
        }
    }
}