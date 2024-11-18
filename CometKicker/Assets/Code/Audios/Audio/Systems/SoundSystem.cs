using System.Collections.Generic;
using Code.Gameplay.Audio.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Audio.Systems
{
    public class SoundSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IGroup<AudioEntity> _sounds;
        private readonly IGroup<AudioEntity> _soundSources;
        private List<AudioEntity> _buffer = new (3);

        public SoundSystem(AudioContext context, IAudioService audioService)
        {
            _audioService = audioService;
            _sounds = context.GetGroup(AudioMatcher.AllOf(
                    AudioMatcher.Sound
            )
                .NoneOf(AudioMatcher.Processed));            
            
            _soundSources = context.GetGroup(AudioMatcher.AllOf(
                AudioMatcher.SoundSource
            ));
        }

        public void Execute()
        {
            foreach (AudioEntity sound in _sounds.GetEntities(_buffer))
            foreach (AudioEntity source in _soundSources)
            {
                source.SoundSource.PlayOneShot(_audioService.GetSound(sound.Sound));
                sound.isProcessed = true;
            }
        }
    }
}