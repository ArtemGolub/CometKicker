using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.SaveLoad;
using UnityEngine;
using YG;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadProgressState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISaveLoadService _saveLoadService;

    public LoadProgressState(
      IGameStateMachine stateMachine,
      ISaveLoadService saveLoadService)
    {
      _saveLoadService = saveLoadService;
      _stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
      YandexGame.OnGameReadyIP += InitializeProgress;
      YandexGame.GameReadyAPI();
    }

    private void InitializeProgress()
    {
      if (_saveLoadService.HasSavedProgress)
        _saveLoadService.LoadProgress();
      else
        CreateNewProgress();
      
      _stateMachine.Enter<ActualizeProgressState>();
    }
    
    private void CreateNewProgress()
    {
      _saveLoadService.CreateProgress();
      
      CreateMetaEntity.Empty()
        .With(e => e.isScoreStorage = true)
        .AddCurrentScore(0)
        .AddMaxScore(0);
    }
  }
}