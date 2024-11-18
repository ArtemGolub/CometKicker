using System.Collections.Generic;
using Code.Infrastructure.Views.Fabrics;
using Entitas;

namespace Code.Infrastructure.Views.Systems
{
    public class BindAudioEntityViewFromPrefabSystem : IExecuteSystem
    {
        private readonly IAudioEntityViewFactory _gameEntityViewFactory;
        private readonly IGroup<AudioEntity> _entities;
        private readonly List<AudioEntity> _buffer = new(32);

        public BindAudioEntityViewFromPrefabSystem(AudioContext contextParameter, IAudioEntityViewFactory gameEntityViewFactory)
        {
            _gameEntityViewFactory = gameEntityViewFactory;
            _entities = contextParameter.GetGroup(AudioMatcher
                .AllOf(AudioMatcher.ViewPrefab)
                .NoneOf(AudioMatcher.View)
            );
        }

        public void Execute()
        {
            foreach (AudioEntity entity in _entities.GetEntities(_buffer))
            {
                _gameEntityViewFactory.CreateViewForEntityFromPrefab(entity);
            }
        }
    }
}