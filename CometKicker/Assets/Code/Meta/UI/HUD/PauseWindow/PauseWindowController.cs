using Code.Gameplay;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Pause;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseWindowController : BaseWindow
{
    [SerializeField] private Button ReturnHomeButton;
    [SerializeField] private Button ContinueButton;

    private PauseWindowModel _model;

    [Inject]
    private void Construct(
        IGameStateMachine stateMachine, 
        IWindowService windowService, 
        IAudioFactory audioFactory, 
        IBattleFeatureService battleFeatureService,
        IGameStateMachine gameStateMachine)
    {
        Id = WindowId.PauseWindow;
        _model = new PauseWindowModel(Id, audioFactory, windowService, battleFeatureService, gameStateMachine);
    }

    protected override void Initialize()
    {
        ReturnHomeButton.onClick.AddListener(_model.ReturnHome);
        ContinueButton.onClick.AddListener(_model.Continue);
    }
    protected override void Cleanup()
    {
        ReturnHomeButton.onClick.RemoveListener(_model.ReturnHome);
        ContinueButton.onClick.RemoveListener(_model.Continue);
    }


}
