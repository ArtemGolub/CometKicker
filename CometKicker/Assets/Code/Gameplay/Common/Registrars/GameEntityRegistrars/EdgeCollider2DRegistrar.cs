using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class EdgeCollider2DRegistrar: GameEntityComponentRegistrar
    {
        public EdgeCollider2D EdgeCollider2D;
        public override void RegisterComponents()
        {
            Entity
                .AddEdgeCollider2D(EdgeCollider2D);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasEdgeCollider2D)
            {
                Entity
                    .RemoveEdgeCollider2D();
            }
        }
    }
}