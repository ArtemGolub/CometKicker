using Code.Gameplay.UI.Services;
using Code.Gameplay.Windows;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.UI
{
    public class CurrentScoreBarController: BaseWindow
    {
        [SerializeField] private TextMeshProUGUI ScoreText;
        private CurrentScoreBarModel _model;
        private ICurrentScoreBarService _currentScoreBarService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService, ICurrentScoreBarService currentScoreBarService)
        {
            Id = WindowId.CurrentScoreWindow;
            _model = new CurrentScoreBarModel();
            _currentScoreBarService = currentScoreBarService;
            _windowService = windowService;
        }
        protected override void Initialize()
        {
            _currentScoreBarService.SetCurrentScoreBar(this);
        }
        public void SetScore(float value)
        {
            ScoreText.text = _model.SetScore(value);
        }
        protected override void Cleanup()
        {
            _currentScoreBarService.SetCurrentScoreBar(null);
            _windowService.Close(Id);
        }
    }
}