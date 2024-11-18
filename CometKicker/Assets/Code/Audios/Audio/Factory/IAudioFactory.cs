using UnityEngine;

namespace Code.Gameplay.Audio.Factory
{
    public interface IAudioFactory
    {
        AudioEntity CreateMusic(MusicTypeId musicTypeId);        
        AudioEntity CreateSound(SoundTypeId soundTypeId);
        AudioEntity CreateMusicSource(Vector3 at);
        AudioEntity CreateSoundSource(Vector3 at);        
        AudioEntity CreateAuidioListener(Vector3 at);
        AudioEntity CreateMusicVolumeChanger(float volume);
        AudioEntity CreateSoundVolumeChanger(float volume);
    }
}