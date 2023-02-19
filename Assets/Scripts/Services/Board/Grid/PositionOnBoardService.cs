using UnityEngine;

namespace App.Services.Board.Grid
{
    public class PositionOnBoardService : IPositionOnBoardService
    {
        public Vector3 PositionOnBoardToWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.X, gridPosition.Y);
        }
    }
}