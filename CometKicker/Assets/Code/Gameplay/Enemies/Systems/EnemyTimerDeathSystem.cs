using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Factory;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyTimerDeathSystem: IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGroup<GameEntity> _enemies;
        private List<GameEntity> _buffer = new (12);


        public EnemyTimerDeathSystem(GameContext contextParameter, ITimeService timeService, IEnemyFactory enemyFactory)
        {
            _timeService = timeService;
            _enemyFactory = enemyFactory;
            _enemies = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.DeathTimer
            ));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
            {
                enemy.ReplaceDeathTimer(enemy.DeathTimer - _timeService.DeltaTime);
                if (enemy.DeathTimer <= 0)
                {
                    _enemyFactory.RecycleEnemy(enemy);
                }
            }
        }
    }
}