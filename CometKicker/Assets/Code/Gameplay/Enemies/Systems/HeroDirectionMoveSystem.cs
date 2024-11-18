using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class HeroDirectionMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;
        private List<GameEntity> _buffer = new(32);

        public HeroDirectionMoveSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.WorldPosition
            )
                .NoneOf(GameMatcher.DirectionSet));

            _heroes = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition
            ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
            {
                enemy.ReplaceDirection((hero.WorldPosition - enemy.WorldPosition).normalized);
                enemy.isMoving = true;
                enemy.isDirectionSet = true;
            }
        }
    }
}