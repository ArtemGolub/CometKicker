using Code.Gameplay.UI;
using Code.Infrastructure.Views.Registrars;
using UnityEngine.Serialization;

namespace Code.Gameplay.Common.Registrars
{
    public class CurrentScoreBarRegistrar: GameEntityComponentRegistrar
    {
        [FormerlySerializedAs("scoreBarController")] [FormerlySerializedAs("ScoreBar")] public BestScoreBarController bestScoreBarController;
        
        public override void RegisterComponents()
        {
            Entity
                .AddCurrenScoreContainer(bestScoreBarController);
        }
        public override void UnRegisterComponents()
        {
            if (Entity.hasCurrenScoreContainer)
            {
                Entity
                    .RemoveCurrenScoreContainer();
            }
        }
    }
}