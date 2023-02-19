using App.Services.Board.Grid;

namespace App.Ecs.Item.Swap.Undo
{
    public readonly struct UndoSwapComponent
    {
        public readonly GridPosition PreviousPosition;

        public UndoSwapComponent(GridPosition previousPosition)
        {
            PreviousPosition = previousPosition;
        }
    }
}