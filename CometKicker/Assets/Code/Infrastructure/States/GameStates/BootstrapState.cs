using Code.Gameplay.Audio.Services;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly IAudioService _audioService;

    public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService, IAudioService audioService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
      _audioService = audioService;
    }
    
    public override void Enter()
    {
      _staticDataService.LoadAll();
      _audioService.LoadAll();
      
      _stateMachine.Enter<LoadProgressState>();
    }
  }
}