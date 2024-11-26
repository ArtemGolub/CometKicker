using Code.Gameplay;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Progress.SaveLoad;
using UnityEngine;
using YG;

namespace Code.Infrastructure.States.GameStates
{
  public class GameOverState : EndOfFrameExitState
  {
    private readonly IWindowService _windowService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IBattleFeatureService _battleFeatureService;
    private readonly GameContext _gameContext;

    public GameOverState(
      IWindowService windowService,
      ISaveLoadService saveLoadService, IBattleFeatureService battleFeatureService)
    {
      _windowService = windowService;
      _saveLoadService = saveLoadService;
      _battleFeatureService = battleFeatureService;
    }

    public override void Enter()
    {
      _battleFeatureService.Deactivate();
      _saveLoadService.SaveProgress();
      _windowService.Open(WindowId.GameOverWindow);
      YandexGame.GameplayStop();
    }

    protected override void ExitOnEndOfFrame()
    {
        
    }
  }
}