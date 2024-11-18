using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySequentialSpawnSystem : IExecuteSystem
    {
        private const float SpawnDistanceGap = 2f;
        private const float EnemyNearbyRadius = 1f;
        
        private int _spawnSideIndex = 0;
        private readonly ITimeService _timeService;
        private readonly IEnemyFactory _enemyFactory;

        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _cameras;
        private readonly IGroup<GameEntity> _enemies;

        private readonly Vector2[] _spawnDirections = new Vector2[]
        {
            Vector2.up, Vector2.right, Vector2.down, Vector2.left
        };

        private List<GameEntity> _buffer = new (16);

        public EnemySequentialSpawnSystem(GameContext contextParameter,
            ITimeService timeService, IEnemyFactory enemyFactory)
        {
            _timeService = timeService;
            _enemyFactory = enemyFactory;
            _timers = contextParameter.GetGroup(GameMatcher.SpawnTimer);

            _cameras = contextParameter.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Camera,
                GameMatcher.MainCamera
            ));
            
            _enemies = contextParameter.GetGroup(GameMatcher.Enemy);
        }

        public void Execute()
        {
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);
                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(Random.Range(5, 10));
                    SpawnEnemySequentiallyOutsideCamera();
                }
            }
        }

        private void SpawnEnemySequentiallyOutsideCamera()
        {
            foreach (GameEntity cameraEntity in _cameras)
            {
                var camera = cameraEntity.Camera;
                Vector2 spawnPosition = GetNextSpawnPosition(camera);

                if (!IsEnemyNearby(spawnPosition, EnemyNearbyRadius))
                {
                    _enemyFactory.CreateEnemy(EnemyTypeId.Empty, at: spawnPosition);
                }
            }
        }

        private Vector2 GetNextSpawnPosition(Camera camera)
        {
            Vector2 direction = _spawnDirections[_spawnSideIndex];
            _spawnSideIndex = (_spawnSideIndex + 1) % _spawnDirections.Length;

            float offsetDistance = direction.x != 0
                ? GetScreenWorldWidth(camera) / 2 + SpawnDistanceGap
                : GetScreenWorldHeight(camera) / 2 + SpawnDistanceGap;

            float randomOffset = direction.x != 0
                ? Random.Range(-GetScreenWorldHeight(camera) / 2, GetScreenWorldHeight(camera) / 2)
                : Random.Range(-GetScreenWorldWidth(camera) / 2, GetScreenWorldWidth(camera) / 2);

            return (Vector2)camera.transform.position + direction * offsetDistance +
                   (direction.x != 0 ? Vector2.up : Vector2.right) * randomOffset;
        }

        private bool IsEnemyNearby(Vector2 position, float radius)
        {
            float sqrRadius = radius * radius; 

            foreach (var enemy in _enemies.GetEntities(_buffer))
            {
                if (((Vector2)enemy.WorldPosition - position).sqrMagnitude < sqrRadius)
                {
                    return true;
                }
            }
            return false;
        }

        private float GetScreenWorldWidth(Camera camera)
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float worldHeight = camera.orthographicSize * 2;
            return (screenWidth / screenHeight) * worldHeight;
        }

        private float GetScreenWorldHeight(Camera camera)
        {
            return camera.orthographicSize * 2;
        }
    }
}
