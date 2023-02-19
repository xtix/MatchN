using App.Services.Board.Grid;

namespace App.Ecs.Spawn
{
    public readonly struct SpawnPositionComponent
    {
        public readonly GridPosition Value;

        public SpawnPositionComponent(GridPosition value)
        {
            Value = value;
        }
    }
}