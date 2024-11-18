using Code.Gameplay.TextureMovement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.TextureMovement
{
    public class TextureMovementFeature: Feature
    {
        public TextureMovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<InfinityTextureMoveSystem>());
            Add(systems.Create<TextureOffsetUpdateSystem>());
        }
    }
}