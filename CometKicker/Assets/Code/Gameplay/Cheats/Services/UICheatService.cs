using System;
using UnityEngine.UI;

namespace Code.Gameplay.Cheats.Services
{
    public class UICheatService : IUICheatService
    {
        private Button _restoreHpButton;
        
        public UICheatService()
        {
            
        }

        public void SetButton(Button restoreHpButton)
        {
            _restoreHpButton = restoreHpButton;
        }
        
        public void OnRestoreHpButton(Action restoreHpAction)
        {
            _restoreHpButton.onClick.AddListener(() => restoreHpAction());
        }
    }
}