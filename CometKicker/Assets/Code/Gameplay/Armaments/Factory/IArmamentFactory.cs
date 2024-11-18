using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
  public interface IArmamentFactory
  {
    GameEntity CreateMeteor(int level, Vector3 at);
  }
}