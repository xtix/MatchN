using App.Ecs.Board;
using App.Services.Camera;
using Leopotam.Ecs;

namespace App.Ecs.Camera
{
    public sealed class CameraFocusOnBoardSystem : IEcsInitSystem
    {
        private readonly EcsFilter<BoardComponent> _filter;

        private readonly ICameraService _cameraService;

        public CameraFocusOnBoardSystem(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void Init()
        {
            foreach (int i in _filter)
            {
                ref BoardComponent boardComponent = ref _filter.Get1(i);
                
                _cameraService.FocusOnBoard(boardComponent.BoardSize);
            }
        }
    }
}