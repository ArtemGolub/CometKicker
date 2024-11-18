
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Score.Systems
{
    public class EncreaseScoreByDestructedArmaments : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _storages;
        private readonly IGroup<GameEntity> _armaments;

        public EncreaseScoreByDestructedArmaments(GameContext contextParameter, MetaContext meta)
        {
            _storages = meta.GetGroup(MetaMatcher.ScoreStorage);            
            
            _armaments = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.ScoreContains,
                GameMatcher.CollisionEffect,
                GameMatcher.Reached
            ));
            
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            foreach (MetaEntity storage in _storages)
            {
                storage.ReplaceCurrentScore(storage.CurrentScore + armament.ScoreContains);
            }
        }
    }
}