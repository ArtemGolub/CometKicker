using System.Collections.Generic;
using Code.Infrastructure.Views.Fabrics;
using Entitas;

namespace Code.Infrastructure.Views.Systems
{
    public class BindEntityViewFromPathSystem : IExecuteSystem
    {
        private readonly IGameEntityViewFactory _gameEntityViewFactory;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public BindEntityViewFromPathSystem(GameContext contextParameter, IGameEntityViewFactory gameEntityViewFactory)
        {
            _gameEntityViewFactory = gameEntityViewFactory;
            _entities = contextParameter.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPath)
                .NoneOf(GameMatcher.View)
            );
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                _gameEntityViewFactory.CreateViewForEntity(entity);
            }
        }
    }
}