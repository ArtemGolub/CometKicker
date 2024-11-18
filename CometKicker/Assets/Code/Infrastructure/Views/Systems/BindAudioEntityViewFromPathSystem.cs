using System.Collections.Generic;
using Code.Infrastructure.Views.Fabrics;
using Entitas;

namespace Code.Infrastructure.Views.Systems
{
    public class BindAudioEntityViewFromPathSystem : IExecuteSystem
    {
        private readonly IAudioEntityViewFactory _audioEntityViewFactory;
        private readonly IGroup<AudioEntity> _entities;
        private readonly List<AudioEntity> _buffer = new(32);

        public BindAudioEntityViewFromPathSystem(AudioContext contextParameter, IAudioEntityViewFactory audioEntityViewFactory)
        {
            _audioEntityViewFactory = audioEntityViewFactory;
            _entities = contextParameter.GetGroup(AudioMatcher
                .AllOf(AudioMatcher.ViewPath)
                .NoneOf(AudioMatcher.View)
            );
        }

        public void Execute()
        {
            foreach (AudioEntity entity in _entities.GetEntities(_buffer))
            {
                _audioEntityViewFactory.CreateViewForEntity(entity);
            }
        }
    }
}