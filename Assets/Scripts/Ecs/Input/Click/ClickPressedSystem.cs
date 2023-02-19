using App.Services.Input;
using Leopotam.Ecs;

namespace App.Ecs.Input.Click
{
    public sealed class ClickPressedSystem: IEcsRunSystem
    {
        private readonly EcsWorld _world;

        private readonly IInputService _inputService;

        public ClickPressedSystem(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Run()
        {
            if (!_inputService.ClickPressed)
                return;

            _world.NewEntity().Replace(
                new ClickEvent(_inputService.PointerPosition));
        }
    }
}