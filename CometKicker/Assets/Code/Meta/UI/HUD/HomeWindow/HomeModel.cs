using System.Threading.Tasks;
using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Code.Meta.UI.HUD.HomeWindow
{
    public class HomeModel
    {
        private const string BattleSceneName = "GameScene";
        
        private readonly IGameStateMachine _stateMachine;
        private readonly IAudioFactory _audioFactory;
        private readonly IWindowService _windowService;
        
        public HomeModel(IGameStateMachine gameStateMachine, IAudioFactory audioFactory, IWindowService windowService)
        {
            _stateMachine = gameStateMachine;
            _audioFactory = audioFactory;
            _windowService = windowService;
        }
        
        public async void EnterBattleLoadingState()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _windowService.Close(WindowId.HomeWindow);
            await Task.Delay(100);
            _stateMachine.Enter<LoadingBattleState, string>(BattleSceneName);
        }

        public void Settings()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _windowService.Close(WindowId.HomeWindow);
            _windowService.Open(WindowId.SettingsWindow);
        }
        
        public void Exit()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            Application.Quit();
        }
        
    }
}