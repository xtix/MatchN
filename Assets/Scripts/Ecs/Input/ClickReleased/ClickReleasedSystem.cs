using App.Services.Input;
using Leopotam.Ecs;

namespace App.Ecs.Input.ClickReleased
{
    public sealed class ClickReleasedSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        
        private readonly IInputService _inputService;

        public ClickReleasedSystem(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Run()
        {
            if (!_inputService.ClickReleased)
                return;
                
            _world.NewEntity().Get<ClickReleasedEvent>();
        }
    }
}