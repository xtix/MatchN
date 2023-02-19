using UnityEngine;
using Zenject;

namespace App.Services.Input
{
    public class InputService: IInputService, IInitializable
    {
        private readonly Controls.Controls _controls;

        public InputService(Controls.Controls controls)
        {
            _controls = controls;
        }

        public bool ClickPressed => _controls.Player.Click.WasPressedThisFrame();
        public bool ClickReleased => _controls.Player.Click.WasReleasedThisFrame();
        public Vector2 PointerPosition => _controls.Player.Pointer.ReadValue<Vector2>();

        public void Initialize()
        {
            _controls.Player.Enable();
        }
    }
}