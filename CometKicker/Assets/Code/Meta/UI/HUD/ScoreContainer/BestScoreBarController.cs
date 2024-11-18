using Code.Gameplay.Windows;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.UI
{
    public class BestScoreBarController : BaseWindow
    {
        [SerializeField] private TextMeshProUGUI ScoreText;
        private BestScoreBarModel _model;
        private IBestScoreBarService _bestScoreBarService;
        private bool isScoreSeted;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService, IBestScoreBarService bestScoreBarService)
        {
            Id = WindowId.BestScoreWindow;
            _model = new BestScoreBarModel();
            _bestScoreBarService = bestScoreBarService;
            _windowService = windowService;
        }
        protected override void Initialize()
        {
            _bestScoreBarService.SetBestScoreBar(this);
        }
        public void SetScore(float value)
        {
            if(isScoreSeted) return;
            ScoreText.text = _model.SetScore(value);
            isScoreSeted = true;
        }

        protected override void Cleanup()
        {
            _bestScoreBarService.SetBestScoreBar(null);
            isScoreSeted = false;
            _windowService.Close(Id);
        }
    }
}