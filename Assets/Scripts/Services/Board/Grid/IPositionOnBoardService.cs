using UnityEngine;

namespace App.Services.Board.Grid
{
    public interface IPositionOnBoardService
    {
        Vector3 PositionOnBoardToWorldPosition(GridPosition gridPosition);
    }
}