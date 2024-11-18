using Code.Infrastructure.Views.AudioViews;
using Code.Meta.UI.HUD.SettingsWindow;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Audio
{
    [Audio] public class MusicSource : IComponent { public AudioSource Value; }
    [Audio] public class SoundSource : IComponent { public AudioSource Value; }
    [Audio] public class MusicComponent : IComponent { public MusicTypeId Value; }
    [Audio] public class SoundComponent : IComponent { public SoundTypeId Value; }
    [Audio] public class Processed : IComponent { }
    
    [Audio] public class SettingsControllerComponent : IComponent { public SettingsController Value; }
    
    [Audio] public class MusicVolumeChanger : IComponent { }
    [Audio] public class SoundVolumeChanger : IComponent { }
    [Audio] public class Volume : IComponent { public float Value; }
    
    
    [Audio] public class View : IComponent { public IEntityAudioView Value; }
    [Audio] public class ViewPath : IComponent { public string Value; }
    [Audio] public class ViewPrefab : IComponent { public AudioEntityBehaviour Value; }
    [Audio] public class SelfDestructTimer : IComponent { public float Value; }

}