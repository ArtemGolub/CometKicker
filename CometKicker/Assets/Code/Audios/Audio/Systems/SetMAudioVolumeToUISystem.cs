using Code.Meta.UI.HUD.SettingsWindow.Services;
using Entitas;

namespace Code.Gameplay.Audio.Systems
{
    public class SetMAudioVolumeToUISystem : IExecuteSystem
    {
        private readonly ISettingsService _settingsService;
        private readonly IGroup<AudioEntity> soundSoruces;


        public SetMAudioVolumeToUISystem(AudioContext auidioContext, ISettingsService settingsService)
        {
            _settingsService = settingsService;
            soundSoruces = auidioContext.GetGroup(AudioMatcher.AllOf(
                AudioMatcher.SoundSource,
                AudioMatcher.Volume
            ));
        }

        public void Execute()
        {
            if (!_settingsService.IsInitializing && !_settingsService.IsUserInteracting)
            {
                foreach (AudioEntity soundSource in soundSoruces)
                {
                    var controller = _settingsService.GetAudioSettingsController();
                    if (controller == null) continue;
                    
                    controller.SetAudioVolume(soundSource.Volume);
                }
            }
        }
    }
}