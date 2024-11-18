namespace Code.Meta.UI.HUD.SettingsWindow.Services
{
    public interface ISettingsService
    {
        bool IsUserInteracting { get; set; }
        bool IsInitializing { get; set; }


        
        SettingsController SetAuidioSettingsController(SettingsController settingsController);
        SettingsController GetAudioSettingsController();
    }
}