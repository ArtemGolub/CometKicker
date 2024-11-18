using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.GameOver.UI
{
    public class GameOverWindow : BaseWindow
    {
        [SerializeField] private Button ReturnHomeButton;
        private GameOverWindowModel _model;
        
        [Inject]
        private void Construct(IGameStateMachine stateMachine, IWindowService windowService, IAudioFactory audioFactory)
        {
            Id = WindowId.GameOverWindow;
            _model = new GameOverWindowModel(Id, stateMachine, windowService, audioFactory);
        }

        protected override void Initialize()
        {
            ReturnHomeButton.onClick.AddListener(_model.ReturnHome);
        }
        
        protected override void Cleanup()
        {
            ReturnHomeButton.onClick.RemoveAllListeners();
        }
    }
}