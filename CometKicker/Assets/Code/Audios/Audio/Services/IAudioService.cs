using UnityEngine;

namespace Code.Gameplay.Audio.Services
{
    public interface IAudioService
    {
        void LoadAll();
        void LoadMusics();
        void LoadSounds();
        AudioClip GetMusic(MusicTypeId musicId);
        AudioClip GetSound(SoundTypeId soundId);
    }
}