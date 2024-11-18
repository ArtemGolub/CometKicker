using Code.Gameplay.Audio.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Audio.Systems
{
    public class InitializeAudioSystem: IInitializeSystem
    {
        private readonly IAudioFactory _audioFactory;
        private static bool initialized = false;

        public InitializeAudioSystem(IAudioFactory audioFactory)
        {
            _audioFactory = audioFactory;
        }

        public void Initialize()
        {
            if(initialized) return;
            _audioFactory.CreateAuidioListener(Vector3.zero);
            _audioFactory.CreateMusicSource(Vector3.zero);
            _audioFactory.CreateSoundSource(Vector3.zero);
            initialized = true;
        }
    }
}