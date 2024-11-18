using Code.Gameplay.Audio.Systems;
using Code.Infrastructure.Systems;

namespace Code.Audios.Audio
{
    public class AudioFeature: Feature
    {
        public AudioFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeAudioSystem>());
            
            Add(systems.Create<MusicSystem>());
            Add(systems.Create<SoundSystem>());
            
            Add(systems.Create<SetMusicVolumeToUISystem>());
            Add(systems.Create<SetMAudioVolumeToUISystem>());
            
            Add(systems.Create<ChangeMusicVolumeSettingSystem>());
            Add(systems.Create<ChangeSoundVolumeSettingSystem>());
            
            Add(systems.Create<SetVolumeToSource>());

            
            Add(systems.Create<CleanUpProcessedMusics>());
            Add(systems.Create<CleanUpProcessedSounds>());
            
            Add(systems.Create<CleanUpAudioSystem>());
        }
    }
}