using System;
using UnityEngine.UI;

namespace Code.Gameplay.Cheats.Services
{
    public interface IUICheatService
    {
        void SetButton(Button restoreHpButton);
        void OnRestoreHpButton(Action restoreHpAction);
    }
}