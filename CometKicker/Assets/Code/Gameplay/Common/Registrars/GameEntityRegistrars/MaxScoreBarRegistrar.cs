using Code.Gameplay.UI;
using Code.Infrastructure.Views.Registrars;
using UnityEngine.Serialization;

namespace Code.Gameplay.Common.Registrars
{
    public class MaxScoreBarRegistrar: GameEntityComponentRegistrar
    {
        [FormerlySerializedAs("scoreBarController")] [FormerlySerializedAs("ScoreBar")] public BestScoreBarController bestScoreBarController;
        public override void RegisterComponents()
        {
            Entity
                .AddMaxScoreContainer(bestScoreBarController);
        }
        public override void UnRegisterComponents()
        {
            if (Entity.hasMaxScoreContainer)
            {
                Entity
                    .RemoveMaxScoreContainer();
            }
        }
    }
}