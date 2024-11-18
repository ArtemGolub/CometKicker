using System;
using Code.Gameplay.Enemies.Factory;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IStaticDataService _staticDataService;
        private readonly EnemyPool _enemyPool;
        private readonly EmptyEnemyFactory _emptyEnemyFactory;

        public EnemyFactory(IIdentifierService identifierService, IAbilityUpgradeService abilityUpgradeService, IStaticDataService staticDataService)
        {
            _abilityUpgradeService = abilityUpgradeService;
            _staticDataService = staticDataService;
            _enemyPool = new EnemyPool();
            _emptyEnemyFactory = new EmptyEnemyFactory(identifierService, _enemyPool);
        }
        public GameEntity CreateEnemy(EnemyTypeId typeID, Vector3 at)
        {
            switch (typeID)
            {
                case EnemyTypeId.Empty:
                    GameEntity enemy = _emptyEnemyFactory.GetOrCreateEmptyEnemy(at);
                    _abilityUpgradeService.InitializeEnemyAbility
                        (enemy.Id, AbilityId.Meteor, 1,_staticDataService.GetAbilityConfig(AbilityId.Meteor).Levels.Count);
                    break;
                case EnemyTypeId.Unknown:
                    Debug.LogWarning($"Enemy with type id: {typeID} not implemented");
                    break;
                default:
                    throw new Exception($"Enemy with type id {typeID} does not exist");
            }
            return null;
        }

        
        public void RecycleEnemy(GameEntity entity)
        {
            entity.isEnemy = false;
            entity.isTurnedAlongDirection = false;
            entity.isMovementAvailable = false;
            entity.isDirectionSet = false;

            _enemyPool.ReturnToPool(entity);
        }

        public void ClearPool()
        {
            _enemyPool.ClearPool();
        }
    }
}