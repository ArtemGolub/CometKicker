using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class MusicSourceRegistrar: AudioEntityComponentRegistrar
    {
        public AudioSource MusicSource;
        
        public override void RegisterComponents()
        {
            Entity
                .AddMusicSource(MusicSource);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasMusicSource)
            {
                Entity
                    .RemoveMusicSource();
            }
        }
    }
}