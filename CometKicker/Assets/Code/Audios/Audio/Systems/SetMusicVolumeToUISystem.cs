using Code.Meta.UI.HUD.SettingsWindow.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Audio.Systems
{
    public class SetMusicVolumeToUISystem : IExecuteSystem
    {
        private readonly ISettingsService _settingsService;
        private readonly IGroup<AudioEntity> musicSources;


        public SetMusicVolumeToUISystem(AudioContext auidioContext, ISettingsService settingsService)
        {
            _settingsService = settingsService;
            musicSources = auidioContext.GetGroup(AudioMatcher.AllOf(
                AudioMatcher.MusicSource,
                AudioMatcher.Volume
                ));
        }

        public void Execute()
        {
            if (!_settingsService.IsInitializing && !_settingsService.IsUserInteracting)
            {
                foreach (AudioEntity musicSource in musicSources)
                {
                    var controller = _settingsService.GetAudioSettingsController();
                    if (controller == null) continue;
            
                    controller.SetMusicVolume(musicSource.Volume);
                }
            }
        }
    }
}