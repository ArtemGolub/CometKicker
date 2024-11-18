using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveHeroToScreenCenterSystem: IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _cameras;

        public MoveHeroToScreenCenterSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.MovableByInput,
                    GameMatcher.WorldPosition,
                    GameMatcher.Direction,
                    GameMatcher.Speed,
                    GameMatcher.MovementAvailable,
                    GameMatcher.Moving,
                    GameMatcher.Dead)
            );

            _cameras = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.MainCamera
            ));
        }

        
        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity camera in _cameras)
            {
                hero.isMovableByInput = false;
                hero.isMoveInCameraBounds = false;
                hero.isMoveWithNoBounds = true;
                
                Vector3 cameraPosition = camera.worldPosition.Value;
                Vector3 screenCenter = cameraPosition;

                hero.ReplaceDirection(screenCenter);
            }
        }
    }
}