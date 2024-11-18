using UnityEngine;

namespace Code.Gameplay.Audio.Configs
{
    [CreateAssetMenu(menuName = "Audio/Music Config", fileName = "MusicConfig")]
    public class MusicConfig: ScriptableObject
    {
        public Music[] Musics;
    }
}