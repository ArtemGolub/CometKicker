using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Pause.Services;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.PauseWindow.PauseButton
{
    public class GamePauseButtonController : BaseWindow
    {
        [SerializeField] private Button PauseButton;
    
        private GamePauseButtonModel _model;
        private IGamePauseButtonService _gamePauseButtonService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(
            IWindowService windowService,
            IGameStateMachine stateMachine, 
            IAudioFactory audioFactory, 
            IGamePauseButtonService gamePauseButtonService)
        {
            Id = WindowId.PauseButtonWindow;
            _model = new GamePauseButtonModel(stateMachine, audioFactory);
            _gamePauseButtonService = gamePauseButtonService;
            _windowService = windowService;
        }
    
        protected override void Initialize()
        {
            _gamePauseButtonService.SetGamePauseButton(this);
            PauseButton.onClick.AddListener(_model.Pause);
        }

        protected override void Cleanup()
        {
            _gamePauseButtonService.SetGamePauseButton(null);
            PauseButton.onClick.RemoveListener(_model.Pause);
            _windowService.Close(Id);
        }
    }
}
