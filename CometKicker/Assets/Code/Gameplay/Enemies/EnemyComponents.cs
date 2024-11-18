using Entitas;

namespace Code.Gameplay.Features.Enemies
{ 
        [Game] public class Enemy : IComponent { } 
        [Game] public class Chasing : IComponent { } 
        [Game] public class DirectionSet : IComponent { } 
        [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
        [Game] public class SpawnTimer : IComponent { public float Value; }
        [Game] public class DeathTimer : IComponent { public float Value; }

}