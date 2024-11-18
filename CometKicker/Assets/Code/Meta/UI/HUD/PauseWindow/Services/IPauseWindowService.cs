namespace Code.Gameplay.Pause.Services
{
    public interface IPauseWindowService
    {
        PauseWindowController SetGamePauseWindowController(PauseWindowController pauseWindowController);
        PauseWindowController GetPauseWindowController();
    }
}