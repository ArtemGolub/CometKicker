using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.HomeWindow
{
    public class HomeController: BaseWindow
    {
        [SerializeField]private Button StartGameButton;
        [SerializeField]private Button SettingsButton;
        [SerializeField]private Button ExitButton;
        
        private HomeModel _homeModel;
        
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IAudioFactory audioFactory, IWindowService windowService)
        {
            Id = WindowId.HomeWindow;
            _homeModel = new HomeModel(gameStateMachine, audioFactory, windowService);
        }
        
        protected override void Initialize()
        {
            StartGameButton.onClick.AddListener(OnStartButton);
            SettingsButton.onClick.AddListener(OnSettingButton);
            ExitButton.onClick.AddListener(OnExitButton);
        }

        protected override void Cleanup()
        {
            StartGameButton.onClick.RemoveAllListeners();
            SettingsButton.onClick.RemoveAllListeners();
            ExitButton.onClick.RemoveAllListeners();
        }

        private void OnStartButton()
        {
            StartGameButton.interactable = false;
            _homeModel.EnterBattleLoadingState();
            StartCoroutine(_homeModel.EnterBattleLoadingStateCoroutine());
        }

        private void OnSettingButton()
        {
            _homeModel.Settings();
        }

        private void OnExitButton()
        {
            _homeModel.Exit();
        }
    }
}