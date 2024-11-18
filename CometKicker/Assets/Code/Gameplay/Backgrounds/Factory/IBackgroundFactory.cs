using UnityEngine;

namespace Code.Gameplay.Backgrounds.Factory
{
    public interface IBackgroundFactory
    {
        GameEntity CreateBackground(Vector3 at);
    }
}