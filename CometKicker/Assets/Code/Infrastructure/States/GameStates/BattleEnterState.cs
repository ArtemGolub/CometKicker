using Code.Gameplay;
using Code.Gameplay.Backgrounds.Factory;
using Code.Gameplay.Cameras;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using UnityEngine;
using YG;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleEnterState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IHeroFactory _heroFactory;
    private readonly IBackgroundFactory _backgroundFactory;
    private readonly ICameraFactory _cameraFactory;
    private readonly ICameraProvider _cameraProvider;
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private BattleFeature _battleFeature;

    public BattleEnterState(
      IGameStateMachine stateMachine, 
      ILevelDataProvider levelDataProvider, 
      IHeroFactory heroFactory,
      IBackgroundFactory backgroundFactory,
      ICameraFactory cameraFactory)
    {
      _stateMachine = stateMachine;
      _levelDataProvider = levelDataProvider;
      _heroFactory = heroFactory;
      _backgroundFactory = backgroundFactory;
      _cameraFactory = cameraFactory;
    }
    
    public override void Enter()
    {
      Debug.Log(" Battle Enter State Enter");
      PlaceHero();
      PlaceBackground();
      PlaceCamera();
      
      _stateMachine.Enter<BattleLoopState>();
      YandexGame.GameplayStart();
    }

    
    private void PlaceCamera()
    {
       _cameraFactory.CreateCamera(_levelDataProvider.StartPoint);
       _cameraFactory.CreateBorderCamera(_levelDataProvider.StartPoint);
    }

    private void PlaceHero()
    {
      _heroFactory.CreateHero(_levelDataProvider.StartPoint);
    }

    private void PlaceBackground()
    {
      _backgroundFactory.CreateBackground(_levelDataProvider.StartPoint);
    }
  }
}