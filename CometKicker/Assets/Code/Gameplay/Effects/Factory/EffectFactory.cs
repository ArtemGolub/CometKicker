using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            switch (setup.EffectTypeId)
            {
                case EffectTypeId.Unknown:
                {
                    break;
                }
                case EffectTypeId.Damage:
                {
                    return CreateDamage(producerId, targetId, setup.Value);
                }
                case EffectTypeId.Heal:
                {
                    return CreateHeal(producerId, targetId, setup.Value);
                }
                case EffectTypeId.ReflectDamage:
                {
                    return CreateRefelctDamage(producerId, targetId, setup.Value);
                }
                case EffectTypeId.AddPoints:
                {
                    return CreateAddPoints(producerId, targetId, setup.Value);
                }
                
            }

            throw new Exception($"Effect with type id {setup.EffectTypeId} does not exist");
        }

        private GameEntity CreateRefelctDamage(int producerId, int targetId, float setupValue)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEffect = true)
                .With(x => x.isDamageEffect = true)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDamageReflection(setupValue)
                .AddEffectValue(setupValue);
        }

        private GameEntity CreateHeal(int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .With(x => x.isEffect = true)
                    .With(x => x.isHealEffect = true)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                ;
        }

        public GameEntity CreateDamage(int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEffect = true)
                .With(x => x.isDamageEffect = true)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddEffectValue(value)
                ;
        }

        public GameEntity CreateAddPoints(int porudcerID, int targetId, float value)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .With(e => e.isEffect = true)
                    .With(e => e.isAddPointsEffect = true)
                    .AddProducerId(porudcerID)
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                ;
        }
    }
}