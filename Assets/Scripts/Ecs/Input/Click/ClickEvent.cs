using UnityEngine;

namespace App.Ecs.Input.Click
{
    public readonly struct ClickEvent
    {
        public readonly Vector2 Value;

        public ClickEvent(Vector2 value)
        {
            Value = value;
        }
    }
}