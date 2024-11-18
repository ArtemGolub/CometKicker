using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.TextureMovement.Systems
{
    public class InfinityTextureMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _infiniteScrollers;

        public InfinityTextureMoveSystem(GameContext contextParameter, ITimeService timeService)
        {
            _timeService = timeService;
            _infiniteScrollers = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.TextureOffSet,
                GameMatcher.InfiniteScroll,
                GameMatcher.Speed,
                GameMatcher.MovementAvailable
                ));
        }
        public void Execute()
        {
            foreach (GameEntity scroller in _infiniteScrollers)
            {
                TextureMoveY(scroller);
            }
        }
        private void TextureMoveY(GameEntity scroller)
        {
            float offsetY = (_timeService.DeltaTime * scroller.Speed) / 10;
            Vector2 newOffSet = new Vector2(scroller.TextureOffSet.x, scroller.TextureOffSet.y - offsetY); 
            scroller.ReplaceTextureOffSet(newOffSet);
        }
    }

}