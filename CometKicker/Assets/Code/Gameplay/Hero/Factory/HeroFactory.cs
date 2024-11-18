using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;


namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector3 at)
        {
            Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
                    .With(x => x[Stats.Speed] = 8)
                    .With(x => x[Stats.MaxHp] = 200)
                ;

            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddBaseStats(baseStats)
                    .AddStatModifiers(InitStats.EmptyStatDictionary())
                    .AddWorldPosition(at)
                    .AddDirection(Vector3.up)
                    .AddSpeed(baseStats[Stats.Speed])
                    .AddCurrentHP(1)
                    .AddMaxHP(baseStats[Stats.MaxHp])
                    
                    .AddViewPath("Gameplay/Hero/Hero")
                    .With(e => e.isHero = true)
                    .With(e => e.isFullRotationAlignedAlongDirection = true)
                    .With(e => e.isMovementAvailable = true)
                    .With(e => e.isMoveInCameraBounds = true)
                    .With(e => e.isMovableByInput = true)
                ;
        }
    }
}