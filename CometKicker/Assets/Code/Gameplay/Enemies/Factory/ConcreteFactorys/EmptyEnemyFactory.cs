using System.IO;
using System.Linq;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Const;
using Code.Gameplay.Enemies.Factory;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EmptyEnemyFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly EnemyPool _enemyPool;
        private readonly string[] _prefabNames;

        public EmptyEnemyFactory(IIdentifierService identifierService, EnemyPool enemyPool)
        {
            _identifierService = identifierService;
            _enemyPool = enemyPool;
            
            _prefabNames = LoadPrefabNames();
        }

        public GameEntity GetOrCreateEmptyEnemy(Vector3 at)
        {
            var goblinEntity = _enemyPool.GetEnemy(EnemyTypeId.Empty);

            if (goblinEntity != null)
            {
                ActivateEmptyEnemy(goblinEntity, at);
                
                return goblinEntity;
            }
            else
            {
                return CreateEnemy(at);
            }
        }

        private void ActivateEmptyEnemy(GameEntity entity, Vector3 at)
        {
            entity
                .ReplaceWorldPosition(at)
                .ReplaceDirection(Vector2.zero)
                .ReplaceViewPath(GetRandomPrefab());
        }

        private GameEntity CreateEnemy(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddEnemyTypeId(EnemyTypeId.Empty)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .With(e => e.isEnemy = true)
                .AddViewPath(GetRandomPrefab());
        }

        private string GetRandomPrefab()
        {
            string prefabName = _prefabNames[Random.Range(0, _prefabNames.Length)];
            return $"Gameplay/Enemy/{prefabName}";
        }

        // private string[] LoadPrefabNames()
        // {
        //     return Directory.GetFiles(GameplayConstans.EnemyPrefabsPath, "*.prefab")
        //         .Select(path => Path.GetFileNameWithoutExtension(path))
        //         .ToArray();
        // }
        private string[] LoadPrefabNames()
        {
            // Используем Resources.LoadAll для загрузки всех префабов в папке "Gameplay/Enemy"
            var prefabs = Resources.LoadAll<GameObject>("Gameplay/Enemy");
            return prefabs.Select(prefab => prefab.name).ToArray();
        }
    }
}
