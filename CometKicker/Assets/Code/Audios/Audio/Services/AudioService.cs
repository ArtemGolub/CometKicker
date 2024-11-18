using System;
using System.Collections.Generic;
using Code.Gameplay.Audio.Configs;
using UnityEngine;

namespace Code.Gameplay.Audio.Services
{
    public class AudioService : IAudioService
    {
        private Dictionary<MusicTypeId, AudioClip> _musicsById = new Dictionary<MusicTypeId, AudioClip>();
        private Dictionary<SoundTypeId, AudioClip> _soundsById = new Dictionary<SoundTypeId, AudioClip>();

        public void LoadAll()
        {
            LoadMusics();
            LoadSounds();
        }

        public void LoadMusics()
        {
           MusicConfig config = Resources.Load<MusicConfig>("Configs/Musics/MusicConfig");
           foreach (Music music in config.Musics)
           {
               _musicsById.Add(music.Type, music.AudioClip);
           }
        }
        public void LoadSounds()
        {
            SoundsConfig config = Resources.Load<SoundsConfig>("Configs/Sounds/SoundsConfig");
            foreach (Sound sound in config.Sounds)
            {
                _soundsById.Add(sound.Type, sound.AudioClip);
            }
        }
        
        public AudioClip GetMusic(MusicTypeId musicId)
        {
            if (_musicsById.TryGetValue(musicId, out AudioClip audioClip))
                return audioClip;
            throw new Exception($"Music clip for {musicId} was not found");
        }
        
        public AudioClip GetSound(SoundTypeId soundId)
        {
            if (_soundsById.TryGetValue(soundId, out AudioClip audioClip))
                return audioClip;
            throw new Exception($"Sound clip for {soundId} was not found");
        }
    }
}