using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Behaviours
{
    public class AuraSizeListener: GameEntityDependent
    {
        public Transform Container;
        private float _radiusPrev;

        private void Update()
        {
            if(Mathf.Abs(Entity.Radius - _radiusPrev) < Mathf.Epsilon)
                return;
            
            SetAuraScale();
        }

        private void SetAuraScale()
        {
            float scale = Entity.Radius * 4; // * 2
            Container.localScale = new Vector3(scale, scale, scale);
            
            _radiusPrev = Entity.Radius;
        }
    }
}