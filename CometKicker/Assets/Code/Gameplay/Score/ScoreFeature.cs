using Code.Gameplay.Score.Systems;
using Code.Infrastructure.Systems;
using Code.Meta.UI;
using UnityEngine;

namespace Code.Gameplay.Score
{
    public class ScoreFeature : Feature
    {
        public ScoreFeature(ISystemFactory systems)
        {
            // Add(systems.Create<EncreaseScoreByTimeSystem>());
            Debug.Log("Score Feature Start Init");
            Add(systems.Create<EncreaseScoreByDestructedArmaments>());
            Add(systems.Create<SetCurrentScoreToUISystem>());
            Add(systems.Create<SetBestScoreToUISystem>());
            Add(systems.Create<SetBestScoreSystem>());
            Add(systems.Create<CleanUpCurrentScoreStorageSystem>());
            Debug.Log("Score Feature End Init");
        }
    }
}