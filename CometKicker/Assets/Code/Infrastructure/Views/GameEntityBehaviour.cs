using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.Views.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Views
{
    public class GameEntityBehaviour: MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;
        public GameEntity Entity => _entity;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry) => 
            _collisionRegistry = collisionRegistry;

        
        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach(IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegisterComponents();

            foreach (Collider2D collider2D in GetComponentsInChildren<Collider2D>(includeInactive:true))
                _collisionRegistry.Register(collider2D.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach(IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnRegisterComponents();
            
            foreach (Collider2D collider2D in GetComponentsInChildren<Collider2D>(includeInactive:true))
                _collisionRegistry.Unregister(collider2D.GetInstanceID());
            
            _entity.Release(this);
            _entity = null;
        }
    }
}