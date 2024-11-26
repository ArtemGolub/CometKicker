using System;
using System.Runtime.InteropServices;

namespace YG
{
    public partial class YandexGame
    {
        private static bool gameReadyUsed;
        public static event Action OnGameReadyIP;

        [StartYG]
        public static void InitGRA()
        {
            if (Instance.infoYG.autoGameReadyAPI)
                GameReadyAPI();
        }

        [DllImport("__Internal")]
        private static extern void GameReadyAPI_js();

        public static void GameReadyAPI()
        {
            if (!gameReadyUsed)
            {
                gameReadyUsed = true;
                OnGameReadyIP?.Invoke();
#if !UNITY_EDITOR
                GameReadyAPI_js();
#endif
            }
        }
        public void _GameReadyAPI() => GameReadyAPI();
    }
}
