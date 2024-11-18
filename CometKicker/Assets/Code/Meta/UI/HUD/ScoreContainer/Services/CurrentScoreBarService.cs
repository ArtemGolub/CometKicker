namespace Code.Gameplay.UI.Services
{
    public class CurrentScoreBarService : ICurrentScoreBarService
    {
        private CurrentScoreBarController _currentScoreBarController;
        public CurrentScoreBarController SetCurrentScoreBar(CurrentScoreBarController currentScoreBarController)
        {
            _currentScoreBarController = currentScoreBarController;
            return _currentScoreBarController;
        }
        public CurrentScoreBarController GetCurrentScoreBar()
        {
            return _currentScoreBarController;
        }   
    }
}