using Code.Audios.Audio;
using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Backgrounds.Factory;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;
using Code.Progress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class HomeScreenState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private readonly IAudioFactory _audioFactory;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IBackgroundFactory _backgroundFactory;
    private readonly ILevelDataProvider _levelDataProvider;
    private HomeScreenFeature _homeScreenFeature;
    private AudioFeature _audioFeature;

    public HomeScreenState(
      ISystemFactory systems, 
      GameContext gameContext,
      IAudioFactory audioFactory, ISaveLoadService saveLoadService, IBackgroundFactory backgroundFactory, ILevelDataProvider levelDataProvider)
    {
      _systems = systems;
      _gameContext = gameContext;
      _audioFactory = audioFactory;
      _saveLoadService = saveLoadService;
      _backgroundFactory = backgroundFactory;
      _levelDataProvider = levelDataProvider;
    }
    
    public override void Enter()
    {
      
      _homeScreenFeature = _systems.Create<HomeScreenFeature>();
      _homeScreenFeature.Initialize();
      PlaceBackground();
      _audioFactory.CreateMusic(MusicTypeId.HomeScreen);
      _saveLoadService.SaveProgress();
    }

    private void PlaceBackground()
    {
      _backgroundFactory.CreateBackground(_levelDataProvider.StartPoint);
    }
    
    protected override void OnUpdate()
    {
      _homeScreenFeature.Execute();
      _homeScreenFeature.Cleanup();
    }

    protected override void ExitOnEndOfFrame()
    {
      _homeScreenFeature.DeactivateReactiveSystems();
      _homeScreenFeature.ClearReactiveSystems();


      DestructEntities();
      
      _homeScreenFeature.Cleanup();
      _homeScreenFeature.TearDown();
      _homeScreenFeature = null;
    }
    
    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;      
    }
  }
}