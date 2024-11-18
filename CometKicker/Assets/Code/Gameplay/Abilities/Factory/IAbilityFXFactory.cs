using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFXFactory
    {
        GameEntity CreateExplosiveFX(Vector3 at);
    }
}