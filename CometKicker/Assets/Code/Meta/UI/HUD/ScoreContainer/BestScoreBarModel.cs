using Code.Common.Helpers;

namespace Code.Gameplay.UI
{
    public class BestScoreBarModel
    {
        private const string BestScoreENG = "BEST SCORE: ";
        private const string BestScoreRUS = "Лучший счет: ";
        public string SetScore(float value)
        {
            string scoreText = BestScoreRUS + value.ToString("");
            return StringUpdater.UpdateString(scoreText);
        }
    }
}