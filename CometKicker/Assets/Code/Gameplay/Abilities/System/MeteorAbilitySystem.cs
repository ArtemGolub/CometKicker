using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.System
{
  public class MeteorAbilitySystem : IExecuteSystem
  {
    private readonly List<GameEntity> _buffer = new(32);
    
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;
    private readonly IStaticDataService _staticDataService;
    
    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _enemies;

    public MeteorAbilitySystem(
      GameContext game,
      IArmamentFactory armamentFactory,
      IAbilityUpgradeService abilityUpgradeService,
      IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;
      _abilityUpgradeService = abilityUpgradeService;

      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.VegetableBoltAbility,
          GameMatcher.CooldownUp,
          GameMatcher.ProducerId));

      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));

      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      foreach (GameEntity enemy in _enemies)
      {
        if (_heroes.count <= 0)
          continue;
       
        
        
        int enemyId = enemy.Id;
        if (ability.ProducerId == enemyId)
        {
          int level = _abilityUpgradeService.GetAbilityLevel(enemyId, AbilityId.Meteor);
        
          _armamentFactory
            .CreateMeteor(level, enemy.WorldPosition)
            .AddProducerId(enemy.Id)
            .ReplaceDirection(GetDirectionWithOffset(enemy.WorldPosition)) // FirstAvailableTarget().WorldPosition, enemy.WorldPosition
            .With(x => x.isMoving = true);
        
          ability
            .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.Meteor, level).Cooldown);
        }
      }
    }
    // private Vector3 GetDirectionWithOffset(Vector3 targetPosition, Vector3 enemyPosition)
    // {
    //   Vector3 direction = (targetPosition - enemyPosition).normalized;
    //   Vector3 offsetDirection = direction + (Vector3)RandomOffest();
    //   return offsetDirection;
    // }

    private Vector2 RandomOffest()
    {
      float randomX = Random.Range(-0.2f, 0.2f);
      float randomY = Random.Range(-0.2f, 0.2f);
      return new Vector2(randomX, randomY);
    }
    private Vector3 GetDirectionWithOffset(Vector3 enemyPosition)
    {
      Vector3 randomTargetPosition = GetRandomScreenPosition();
      Vector3 direction = (randomTargetPosition - enemyPosition).normalized;
      Vector3 offsetDirection = direction + (Vector3)RandomOffest();
      return offsetDirection.normalized;
    }

    private Vector3 GetRandomScreenPosition()
    {
      // Получаем размеры экрана
      float randomX = Random.Range(0, Screen.width);
      float randomY = Random.Range(0, Screen.height);
    
      // Преобразуем экранные координаты в мировые
      return Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, Camera.main.nearClipPlane));
    }
    private Vector3 GetDirection(GameEntity enemy)
    {
       return (FirstAvailableTarget().WorldPosition - enemy.WorldPosition).normalized;
    }
    private GameEntity FirstAvailableTarget()
    {
      return _heroes.AsEnumerable().First();
    }
  }
}