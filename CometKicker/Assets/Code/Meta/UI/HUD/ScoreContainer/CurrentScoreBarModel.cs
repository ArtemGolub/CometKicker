using Code.Common.Helpers;

namespace Code.Gameplay.UI
{
    public class CurrentScoreBarModel
    {
        public string SetScore(float value)
        {
            string scoreText = value.ToString("");
            return StringUpdater.UpdateString(scoreText);
        }
    }
}