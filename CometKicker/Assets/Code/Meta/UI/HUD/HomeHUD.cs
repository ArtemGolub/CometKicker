using System;
using Code.Gameplay.Audio;
using Code.Gameplay.Audio.Factory;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.HUD
{
    public class HomeHUD : MonoBehaviour
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
            _audioFactory.CreateMusic(MusicTypeId.HomeScreen);
            
            _windowService.Open(WindowId.BestScoreWindow);
            _windowService.Open(WindowId.HomeWindow);
        }
    }
}