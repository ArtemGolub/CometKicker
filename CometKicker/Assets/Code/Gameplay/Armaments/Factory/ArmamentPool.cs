using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentPool
    {
        private readonly Dictionary<AbilityId, Queue<GameEntity>> _abilityPools = new Dictionary<AbilityId, Queue<GameEntity>>();
        
        public GameEntity GetAbility(AbilityId abilityId)
        {
            if (_abilityPools.TryGetValue(abilityId, out var pool) && pool.Count > 0)
            {
                return pool.Dequeue();
            }
            return CreateNewAbility(abilityId);
        }
        
        public void ReturnAbility(GameEntity entity, AbilityId abilityId)
        {
            if (!_abilityPools.ContainsKey(abilityId))
            {
                _abilityPools[abilityId] = new Queue<GameEntity>();
            }
            _abilityPools[abilityId].Enqueue(entity);
        }

        private GameEntity CreateNewAbility(AbilityId abilityId)
        {
            var newEntity = CreateEntity.Empty();
            if (!_abilityPools.ContainsKey(abilityId))
            {
                _abilityPools[abilityId] = new Queue<GameEntity>();
            }
            _abilityPools[abilityId].Enqueue(newEntity);
            return newEntity;
        }        

    }
}