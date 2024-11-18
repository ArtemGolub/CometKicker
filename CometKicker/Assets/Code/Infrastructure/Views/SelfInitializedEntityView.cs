using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Infrastructure.Views
{
    public class SelfInitializedEntityView : MonoBehaviour
    {
        [FormerlySerializedAs("EntityBehaviour")] public GameEntityBehaviour gameEntityBehaviour;
        private IIdentifierService _identifires;

        [Inject]
        private void Construct(IIdentifierService identifiers) => _identifires = identifiers;

        
        private void Awake()
        {
            GameEntity entity = CreateEntity.Empty()
                .AddId(_identifires.Next());
            
            gameEntityBehaviour.SetEntity(entity);
        }
    }
}