using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitTouchInputSystem : IExecuteSystem
    {
        private readonly ITouchInputService _touchInputService;
        private readonly IGroup<InputEntity> _inputs;

        public EmitTouchInputSystem(InputContext input, ITouchInputService touchInputService)
        {
            _touchInputService = touchInputService;
            _inputs = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                if (_touchInputService.HasTouchInput())
                {
                    Vector2 touchDirection = _touchInputService.GetTouchDirection();
                    input.ReplaceAxisInput(touchDirection);
                }
                else if (input.hasAxisInput)
                {
                    input.RemoveAxisInput();
                }
            }
        }
    }
}