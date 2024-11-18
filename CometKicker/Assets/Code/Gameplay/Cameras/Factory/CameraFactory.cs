using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Cameras.Factory
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IIdentifierService _identifierService;

        public CameraFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateCamera(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddViewPath("Gameplay/Cameras/MainCamera")
                .With(e => e.isActive = false)
                .With(e => e.isMainCamera = true)
                .With(e => e.isPersistent = true);
        }        
        
        public GameEntity CreateBorderCamera(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddViewPath("Gameplay/Cameras/BorderCamera")
                .With(e => e.isActive = false)
                .With(e => e.isBorderCamera = true);
        }
        
    }
}