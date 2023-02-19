using UnityEngine;

namespace App.Services.Input
{
    public interface IInputService
    {
        bool ClickPressed { get; }
        bool ClickReleased { get; }
        Vector2 PointerPosition { get; }
    }
}