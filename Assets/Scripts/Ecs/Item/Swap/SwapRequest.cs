using App.Services.Board.Grid;

namespace App.Ecs.Item.Swap
{
    public readonly struct SwapRequest
    {
        public readonly GridPosition TargetPosition;

        public SwapRequest(GridPosition targetPosition)
        {
            TargetPosition = targetPosition;
        }
    }
}