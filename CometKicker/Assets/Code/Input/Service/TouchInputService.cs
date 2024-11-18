using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public class TouchInputService : ITouchInputService
    {
        private Vector2 _lastDirection;
        private Vector2 _initialTouchPosition;
        private bool _isTouching;
        public bool HasTouchInput() => UnityEngine.Input.touchCount > 0 || UnityEngine.Input.GetMouseButton(0);
        public Vector2 GetTouchDirection()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _initialTouchPosition = touch.position;
                    _isTouching = true;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (_isTouching)
                    {
                        Vector2 currentTouchPosition = touch.position;
                        Vector2 direction = (currentTouchPosition - _initialTouchPosition).normalized;
                        
                        if (direction.magnitude > 0.1f)
                        {
                            _lastDirection = direction;
                        }
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _isTouching = false;
                    _lastDirection = Vector2.zero;
                }
            }
            return _lastDirection;
        }
    }
}
