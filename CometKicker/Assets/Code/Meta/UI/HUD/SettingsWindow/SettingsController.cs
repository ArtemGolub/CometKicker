using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Meta.UI.HUD.SettingsWindow.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.SettingsWindow
{
    public class SettingsController : BaseWindow
    {
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider soundVolumeSlider;
        [SerializeField] private Button returnButton;
        private SettingModel _model;
        private ISettingsService _settingsService;
        private bool musicSeted;
        private bool soundSeted;

        [Inject]
        private void Construct(IAudioFactory audioFactory, IWindowService windowService,
            ISettingsService settingsService)
        {
            Id = WindowId.SettingsWindow;
            _model = new SettingModel(audioFactory, windowService);
            _settingsService = settingsService;
            _settingsService.SetAuidioSettingsController(this);
        }

        protected override void Initialize()
        {
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            soundVolumeSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
            returnButton.onClick.AddListener(OnReturn);
        }

        public void SetMusicVolume(float volume)
        {
            if(musicSeted) return;
            musicVolumeSlider.value = volume;
            musicSeted = true;
        }

        public void SetAudioVolume(float volume)
        {
            if(soundSeted) return;
            soundVolumeSlider.value = volume;
            soundSeted = true;
        }

        private void OnMusicVolumeChanged(float volume)
        {
            _model.ChangeMusicVolumeBySlider(volume);
        }

        private void OnSoundVolumeChanged(float volume)
        {
            _model.ChangeSoundVolumeBySlider(volume);
        }

        private void OnReturn()
        {
            _model.Home();
        }

        protected override void Cleanup()
        {
            musicVolumeSlider.onValueChanged.RemoveAllListeners();
            soundVolumeSlider.onValueChanged.RemoveAllListeners();
            returnButton.onClick.RemoveAllListeners();
            _settingsService.SetAuidioSettingsController(null);
            musicSeted = false;
            soundSeted = false;
        }
    }
}