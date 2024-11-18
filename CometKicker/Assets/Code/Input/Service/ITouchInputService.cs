using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public interface ITouchInputService
    {
        bool HasTouchInput();
        Vector2 GetTouchDirection();
    }
}