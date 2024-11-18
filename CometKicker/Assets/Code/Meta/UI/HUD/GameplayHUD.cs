using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

    public class GameplayHUD: MonoBehaviour
    {
        private IAudioFactory _audioFactory;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IAudioFactory audioFactory, IWindowService windowService)
        {
            _audioFactory = audioFactory;
            _windowService = windowService;
        }
        
        private void Start()
        {
            _audioFactory.CreateMusic(MusicTypeId.GameTheme);
            
            _windowService.Open(WindowId.CurrentScoreWindow);
            _windowService.Open(WindowId.HpBarWindow);
            _windowService.Open(WindowId.PauseButtonWindow);
        }
    }
