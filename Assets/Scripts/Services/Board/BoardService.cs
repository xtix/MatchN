using App.Services.Board.Grid;
using UnityEngine;

namespace App.Services.Board
{
    public class BoardService : IBoardService
    {
        private readonly UnityEngine.Camera _camera;

        public BoardService(UnityEngine.Camera camera)
        {
            _camera = camera;
        }

        public GridPosition ScreenPointerToBoardItemPosition(Vector2 pointerScreenPosition)
        {
            Vector3 pointerWorldPosition = _camera.ScreenToWorldPoint(pointerScreenPosition);

            return new GridPosition(
                Mathf.RoundToInt(pointerWorldPosition.x),
                Mathf.RoundToInt(pointerWorldPosition.y));
        }
    }
}