using Code.Gameplay.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.HPContainer
{
    public class HPBarController: BaseWindow
    {
        [SerializeField] private Slider HealthBar;
        [SerializeField] private Image Fill;

        private HPBarModel _model;
        private IWindowService _windowService;
        private IHPBarService _hpBarService;

        [Inject]
        private void Construct(IWindowService windowService, IHPBarService hpBarService)
        {
            Id = WindowId.HpBarWindow;
            _model = new HPBarModel(HealthBar, Fill);
            _hpBarService = hpBarService;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            _hpBarService.SetHPBar(this);
        }

        public void SetHealth(float heroHp, float maxHp)
        {
            _model.SetHealth(heroHp, maxHp);
        }
        
        protected override void Cleanup()
        {
            _hpBarService.SetHPBar(null);
            _windowService.Close(Id);
        }
    }
}