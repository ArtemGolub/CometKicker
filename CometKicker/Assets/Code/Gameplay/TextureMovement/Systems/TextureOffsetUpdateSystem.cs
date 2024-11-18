using Entitas;

namespace Code.Gameplay.TextureMovement.Systems
{
    public class TextureOffsetUpdateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _textureOffset;

        public TextureOffsetUpdateSystem(GameContext contextParameter)
        {
            _textureOffset = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.MovableTexture,
                GameMatcher.TextureOffSet,
                GameMatcher.MeshRenderer
                ));
        }

        public void Execute()
        {
            foreach (GameEntity texture in _textureOffset)
            {
                UpdateTextureOffset(texture);
            }
        }
        
        private void UpdateTextureOffset(GameEntity texture)
        {
            texture.MeshRenderer.material.SetTextureOffset("_MainTex", texture.TextureOffSet);
        }
    }

}