using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;

namespace Code.Meta.UI.HUD.SettingsWindow
{
    public class SettingModel
    {
        private readonly IAudioFactory _audioFactory;
        private readonly IWindowService _windowService;
        
        public SettingModel(IAudioFactory audioFactory, IWindowService windowService)
        {
            _audioFactory = audioFactory;
            _windowService = windowService;
        }
        
        public void Home()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _windowService.Close(WindowId.SettingsWindow);
            _windowService.Open(WindowId.HomeWindow);
        }

        public void ChangeMusicVolumeBySlider(float volume)
        {
            _audioFactory.CreateMusicVolumeChanger(volume);
        }
        
        public void ChangeSoundVolumeBySlider(float volume)
        {
            _audioFactory.CreateSoundVolumeChanger(volume);
        }
        
    }
}