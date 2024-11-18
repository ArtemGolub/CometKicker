using System.Collections.Generic;
using Code.Gameplay.Features.Enemies;

namespace Code.Gameplay.Enemies.Factory
{
    public class EnemyPool
    {
        private readonly Dictionary<EnemyTypeId, Queue<GameEntity>> _enemyPools;
        
        public EnemyPool()
        {
            _enemyPools = new Dictionary<EnemyTypeId, Queue<GameEntity>>();
        }
        private Queue<GameEntity> GetPool(EnemyTypeId typeID)
        {
            if (!_enemyPools.ContainsKey(typeID))
            {
                _enemyPools[typeID] = new Queue<GameEntity>();
            }
            return _enemyPools[typeID];
        }
        public GameEntity GetEnemy(EnemyTypeId typeID)
        {
            var pool = GetPool(typeID);

            if (pool.Count > 0)
            {
                return pool.Dequeue();
            }

            return null;
        }
        public void ClearPool()
        {
            foreach (var pool in _enemyPools.Values)
            {
                while (pool.Count > 0)
                {
                    GameEntity enemy = pool.Dequeue();
                    enemy.isDead = true;
                    enemy.isProcessingDeath = true;
                }
            }
            _enemyPools.Clear();
        }
        public void ReturnToPool(GameEntity entity)
        {
            var pool = GetPool(entity.enemyTypeId.Value);
            pool.Enqueue(entity);
        }
    }
}