namespace Code.Gameplay.Pause.Services
{
    public class PauseWindowService : IPauseWindowService
    {
        private PauseWindowController _pauseWindowController;
        
        public PauseWindowController SetGamePauseWindowController(PauseWindowController pauseWindowController)
        {
            _pauseWindowController = pauseWindowController;
            return _pauseWindowController;
        }
        public PauseWindowController GetPauseWindowController()
        {
            return _pauseWindowController;
        }  
    }
}