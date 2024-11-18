using Code.Meta.UI.HUD.HPContainer;
using Entitas;

namespace Code.Gameplay.Features.LifeTime.Systems
{
    public class UpdateHealthBarSystem: IExecuteSystem
    {
        private readonly IHPBarService _hpBarService;
        private readonly IGroup<GameEntity> _heroes;
        
        public UpdateHealthBarSystem(GameContext game, IHPBarService hpBarService)
        {
            _hpBarService = hpBarService;
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero, 
                    GameMatcher.CurrentHP));
        }

        public void Execute()
        {
            HPBarController hpBarController = _hpBarService.GetHPBar();
            if(!hpBarController) return;
            foreach (GameEntity hero in _heroes)
                hpBarController.SetHealth(hero.CurrentHP, hero.MaxHP);
        }
    }
}