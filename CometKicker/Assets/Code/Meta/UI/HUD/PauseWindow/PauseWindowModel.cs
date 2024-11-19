using System.Threading.Tasks;
using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;

namespace Code.Gameplay.Pause
{
    public class PauseWindowModel
    {
        private readonly IAudioFactory _audioFactory;
        private readonly IWindowService _windowService;
        private readonly IBattleFeatureService _battleFeatureService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly WindowId _id;

        public PauseWindowModel(
            WindowId windowId,
            IAudioFactory audioFactory, 
            IWindowService windowService, 
            IBattleFeatureService battleFeatureService, 
            IGameStateMachine gameStateMachine)
        {
            _id = windowId;
            _audioFactory = audioFactory;
            _windowService = windowService;
            _battleFeatureService = battleFeatureService;
            _gameStateMachine = gameStateMachine;
        }
        
        public void ReturnHome()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _windowService.Close(_id);
            _battleFeatureService.Deactivate();
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }

        public void Continue()
        {
            _windowService.Close(_id);
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _gameStateMachine.Enter<BattleLoopState>();
        }
    }
}