using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private const float DeathAnimationTime = 0.1f;
        
        public EnemyDeathSystem(GameContext contextParameter)
        {
            _enemies = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.Dead,
                GameMatcher.ProcessingDeath
            ));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isMovementAvailable = false;
                enemy.isTurnedAlongDirection = false;
                
                enemy.ReplaceSelfDestructTimer(DeathAnimationTime);
            }
        }
    }
}