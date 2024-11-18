using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class FinalizeProcessedArmamentsSystem : IExecuteSystem
    {
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _armaments;

        public FinalizeProcessedArmamentsSystem(GameContext contextParameter, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            _armaments = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.Processed
            ));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                armament.RemoveTargetCollectionComponents();
                armament.isDestructed = true;
            }
        }
    }
}