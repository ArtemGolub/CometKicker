using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Cameras
{
    public class CameraFeature: Feature
    {
        public CameraFeature(ISystemFactory systems)
        {
           // Add(systems.Create<CameraBoundsCheckSystem>());
        }
    }
}