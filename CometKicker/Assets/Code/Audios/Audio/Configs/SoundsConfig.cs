using UnityEngine;

namespace Code.Gameplay.Audio.Configs
{
    [CreateAssetMenu(menuName = "Audio/Sound Config", fileName = "SoundConfig")]
    public class SoundsConfig: ScriptableObject
    {
        public Sound[] Sounds;
    }
}