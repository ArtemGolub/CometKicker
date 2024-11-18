using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroDeathSystem : IExecuteSystem
    {
        private const float DeathAnimationTime = 2;
        private readonly IGroup<GameEntity> _heroes;

        public HeroDeathSystem(GameContext contextParameter)
        {
            _heroes = contextParameter.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Hero,
                GameMatcher.Dead,
                GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.isMovementAvailable = false;
                hero.isTurnedAlongDirection = false;
                
                // TODO Remove Collections here
                
                hero.ReplaceSelfDestructTimer(DeathAnimationTime);
            }
        }
    }
}