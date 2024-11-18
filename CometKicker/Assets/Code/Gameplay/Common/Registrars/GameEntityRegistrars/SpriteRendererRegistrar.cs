using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class SpriteRendererRegistrar : GameEntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;
        public override void RegisterComponents()
        {
            Entity
                .AddSpriteRenderer(SpriteRenderer);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasSpriteRenderer)
            {
                Entity
                    .RemoveSpriteRenderer();
            }
        }
    }
}