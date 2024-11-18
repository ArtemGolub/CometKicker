using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessAddScorePointsEffectSystem: IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<MetaEntity> _scorePointsStorages;

        public ProcessAddScorePointsEffectSystem(GameContext game, MetaContext meta)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.AddPointsEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId
            ));

            _scorePointsStorages = meta.GetGroup(MetaMatcher.ScoreStorage);
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            foreach (MetaEntity storage in _scorePointsStorages)
            {
                effect.isProcessed = true;
                storage.ReplaceCurrentScore(storage.CurrentScore + effect.EffectValue);
            }
        }
    }
}