namespace Code.Gameplay.UI.Services
{
    public interface ICurrentScoreBarService
    {
        CurrentScoreBarController SetCurrentScoreBar(CurrentScoreBarController currentScoreBarController);
        CurrentScoreBarController GetCurrentScoreBar();
    }
}