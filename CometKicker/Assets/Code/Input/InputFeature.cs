using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;
using UnityEngine.Device;

namespace Code.Gameplay.Input
{
    public class InputFeature: Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeInputSystem>());
            if (Application.isMobilePlatform)
            {
                Add(systems.Create<EmitTouchInputSystem>());
            }
            else
            {
                Add(systems.Create<EmitInputSystem>());
            }
        }
    }
}