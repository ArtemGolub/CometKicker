using Code.Gameplay.Cheats.Services;
using Entitas;

namespace Code.Gameplay.Cheats.Systems
{
   public class RestoreHeroHpByButtonSystem : IInitializeSystem
    {
        private readonly IUICheatService _uiCheatService;
        private readonly IGroup<GameEntity> _heroes;

        public RestoreHeroHpByButtonSystem(GameContext game, IUICheatService uiCheatService)
        {
            _uiCheatService = uiCheatService;
            
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.CurrentHP
                ));
        }
        
        public void Initialize()
        {
            _uiCheatService.OnRestoreHpButton(OnRestoreHpButton);
        }
        
        private void OnRestoreHpButton()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.ReplaceCurrentHP(hero.CurrentHP + 50);
            }
        }
    }

}