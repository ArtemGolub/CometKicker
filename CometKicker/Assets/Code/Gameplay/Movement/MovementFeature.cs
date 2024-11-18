using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature: Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            Add(systems.Create<DirectionalDeltaMoveWithinCameraBoundsSystem>());

            
            Add(systems.Create<TurnAlongDirectionSystem>());
            Add(systems.Create<RotateAlongDirectionSystem>());
            Add(systems.Create<FullRotateAlongDirectionSystem>());
            Add(systems.Create<RotateRandomDirectionSystem>());
            
          //  Add(systems.Create<MoveHeroToScreenCenterSystem>());
            
            Add(systems.Create<UpdateTransformPositionSystem>());

        }
    }
}