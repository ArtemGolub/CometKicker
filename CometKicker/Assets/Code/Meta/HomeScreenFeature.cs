using Code.Audios.Audio;
using Code.Common.Destruct;
using Code.Gameplay.Backgrounds;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Score;
using Code.Gameplay.TextureMovement;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Meta
{
  public class HomeScreenFeature : Feature
  {
    public HomeScreenFeature(ISystemFactory systems)
    {
      //Add(systems.Create<PeriodicallySaveProgressSystem>(MetaConstants.SaveProgressPeriodSeconds));
      Debug.Log("Home screen feature Start Init");
      Add(systems.Create<BindViewFeature>());
      
      Add(systems.Create<AudioFeature>());

      Add(systems.Create<ScoreFeature>());
      
      Add(systems.Create<TextureMovementFeature>());
      Add(systems.Create<MovementFeature>());
      
      Add(systems.Create<ProcessDestructedFeature>());
      Debug.Log("Home screen feature End Init");
      
    }
  }
}