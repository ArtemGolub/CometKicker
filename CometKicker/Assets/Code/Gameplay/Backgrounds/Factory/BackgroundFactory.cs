using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Backgrounds.Factory
{
    public class BackgroundFactory : IBackgroundFactory
    {
        private readonly IIdentifierService _identifierService;

        public BackgroundFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        
        public GameEntity CreateBackground(Vector3 at)
        {
            Dictionary<Stats, float> baseStats = InitStats
                    .EmptyStatDictionary()
                    .With(x=>x[Stats.Speed] = 1)
                    ;
           
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddBaseStats(baseStats)
                    .AddStatModifiers(InitStats.EmptyStatDictionary())
                    .AddWorldPosition(at)
                    .AddSpeed(baseStats[Stats.Speed])
                    .AddTextureOffSet(Vector2.zero)
                    .AddViewPath("Gameplay/Backgrounds/InfinityBackground")
                    .With(e => e.isMovableTexture = true)
                    .With(e => e.isInfiniteScroll = true)
                    .With(e => e.isMovementAvailable = true)
                    .With(e => e.isBackground = true)
                    ;
        }
    }
}