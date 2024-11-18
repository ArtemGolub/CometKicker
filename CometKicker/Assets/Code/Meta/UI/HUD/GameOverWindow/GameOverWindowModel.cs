using System.Threading.Tasks;
using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;

namespace Code.Gameplay.GameOver.UI
{
    public class GameOverWindowModel
    {
        private readonly WindowId _id;
        private IGameStateMachine _gameStateMachine;
        private IWindowService _windowService;
        private IAudioFactory _audioFactory;
        
        public GameOverWindowModel(WindowId id,IGameStateMachine stateMachine, IWindowService windowService, IAudioFactory audioFactory)
        {
            _id = id;
            _gameStateMachine = stateMachine;
            _windowService = windowService;
            _audioFactory = audioFactory;
        }

        public async void ReturnHome()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _windowService.Close(_id);
            await Task.Delay(100);
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }
    }
}