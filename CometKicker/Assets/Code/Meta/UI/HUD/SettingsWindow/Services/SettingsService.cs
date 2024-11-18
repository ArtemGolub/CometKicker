namespace Code.Meta.UI.HUD.SettingsWindow.Services
{
    public class SettingsService : ISettingsService
    {
        private SettingsController _audioSettingsController;

        public bool IsUserInteracting { get; set; }
        public bool IsInitializing { get; set; }
        
        public SettingsController SetAuidioSettingsController(SettingsController settingsController)
        {
            _audioSettingsController = settingsController;
            return _audioSettingsController;
        }
        public SettingsController GetAudioSettingsController()
        {
            return _audioSettingsController;
        }
        
        

    }
}