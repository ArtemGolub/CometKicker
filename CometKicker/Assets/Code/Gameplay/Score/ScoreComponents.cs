using Code.Gameplay.UI;
using Code.Progress;
using Entitas;

namespace Code.Gameplay.Score
{
    [Meta] public class CurrentScore : ISavedComponent { public float Value; }
    [Meta] public class MaxScore : ISavedComponent { public float Value; }
    [Meta] public class ScoreStorage : ISavedComponent { }
    [Game] public class ScoreContains : IComponent { public float Value; }
    
    [Game] public class CurrenScoreContainer : IComponent { public BestScoreBarController Value; }
    [Game] public class MaxScoreContainer : IComponent { public BestScoreBarController Value; }
}