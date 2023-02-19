using App.Services.Board.Grid;
using UnityEngine;

namespace App.Services.Board
{
    public interface IBoardService
    {
        GridPosition ScreenPointerToBoardItemPosition(Vector2 pointerScreenPosition);
    }
}