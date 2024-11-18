

using Entitas;
using UnityEngine;

namespace Code.Gameplay.TextureMovement
{
    [Game] public class MovableTexture : IComponent {  }
    [Game] public class InfiniteScroll : IComponent {  }
    [Game] public class TextureOffSet : IComponent { public Vector2 Value; }
}

