using Entitas;

namespace Code.Gameplay.Features.Effects
{
    [Game] public class Effect : IComponent { }
    [Game] public class EffectValue : IComponent { public float Value; }
    [Game] public class ProducerId : IComponent { public int Value; }
    [Game] public class TargetId : IComponent { public int Value; }
    
    [Game] public class DamageEffect : IComponent { }
    [Game] public class HealEffect : IComponent { }
    [Game] public class AddPointsEffect : IComponent { }
    
    [Game] public class DamageReflectionComponent : IComponent { public float Value; } 
}