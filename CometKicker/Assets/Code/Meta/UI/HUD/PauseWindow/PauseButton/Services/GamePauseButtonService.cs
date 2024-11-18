using Code.Meta.UI.HUD.PauseWindow.PauseButton;

namespace Code.Gameplay.Pause.Services
{
    public class GamePauseButtonService : IGamePauseButtonService
    {
        private GamePauseButtonController _gamePauseButtonController;
        
        public GamePauseButtonController SetGamePauseButton(GamePauseButtonController gamePauseButtonController)
        {
            _gamePauseButtonController = gamePauseButtonController;
            return _gamePauseButtonController;
        }
        public GamePauseButtonController GetGamePauseButton()
        {
            return _gamePauseButtonController;
        }  
    }
}