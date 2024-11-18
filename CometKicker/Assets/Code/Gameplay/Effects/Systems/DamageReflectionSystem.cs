using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class DamageReflectionSystem: IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damageEffects;

        public DamageReflectionSystem(GameContext gameContext)
        {
            _damageEffects = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.DamageEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId,
                GameMatcher.ProducerId
            ));
        }

        public void Execute()
        {
            foreach (GameEntity damageEffect in _damageEffects)
            {
                GameEntity target = damageEffect.Target();
                if (target.hasDamageReflection)
                {
                    GameEntity producer = damageEffect.Producer();
                    float reflectedDamage = damageEffect.EffectValue * target.DamageReflection;
                    if (producer.isDead) continue; 
                    producer.ReplaceCurrentHP(producer.CurrentHP - reflectedDamage);
                }
                damageEffect.isProcessed = true;
            }
        }
    }
}