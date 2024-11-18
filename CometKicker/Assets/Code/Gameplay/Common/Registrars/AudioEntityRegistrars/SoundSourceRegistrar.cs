using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class SoundSourceRegistrar: AudioEntityComponentRegistrar
    {
        public AudioSource SoundSource;
        
        public override void RegisterComponents()
        {
            Entity
                .AddSoundSource(SoundSource);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasMusicSource)
            {
                Entity
                    .RemoveSoundSource();
            }
        }
    }
}