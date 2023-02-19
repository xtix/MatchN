using App.Services.Board;
using UnityEngine;

namespace App.Services.Camera
{
    public class CameraService: ICameraService
    {
        private readonly UnityEngine.Camera _camera;

        public CameraService(UnityEngine.Camera camera)
        {
            _camera = camera;
        }

        public void FocusOnBoard(BoardSize boardSize)
        {
            Transform cameraTransform = _camera.transform;

            Vector3 position = cameraTransform.position;
            position.x = boardSize.X / 2f;
            position.y = boardSize.Y / 2f;
            cameraTransform.position = position;
        }
    }
}