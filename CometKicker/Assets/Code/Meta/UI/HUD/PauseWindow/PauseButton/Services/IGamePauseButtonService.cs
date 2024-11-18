using Code.Meta.UI.HUD.PauseWindow.PauseButton;

namespace Code.Gameplay.Pause.Services
{
    public interface IGamePauseButtonService
    {
        GamePauseButtonController SetGamePauseButton(GamePauseButtonController gamePauseButtonController);
        GamePauseButtonController GetGamePauseButton();
    }
}