using Code.Gameplay.UI;

public interface IBestScoreBarService
{
    BestScoreBarController SetBestScoreBar(BestScoreBarController bestBestScoreBarController);
    BestScoreBarController GetBestScoreBar();
}