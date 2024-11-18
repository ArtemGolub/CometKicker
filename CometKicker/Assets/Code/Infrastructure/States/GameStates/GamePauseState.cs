using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class GamePauseState:  SimpleState
    {
        private readonly IWindowService _windowService;

        public GamePauseState(
            IWindowService windowService)
        {
            _windowService = windowService;
        }
    
        public override void Enter()
        {
            _windowService.Open(WindowId.PauseWindow);
        }
    }
}