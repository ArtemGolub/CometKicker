using System;
using System.Linq;
using System.Text;
using Code.Common.Entity.ToStrings;
using Code.Common.Extensions;
using Code.Gameplay.Cameras;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.LifeTime;
using Code.Gameplay.Score;
using Entitas;
using UnityEngine;
using Code.Gameplay.Audio;
using Code.Gameplay.Common.Registrars;
using Code.Gameplay.Features.Armaments;
using Background = Code.Gameplay.Backgrounds.Background;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
  private EntityPrinter _printer;

  public override string ToString()
  {
    if (_printer == null)
      _printer = new EntityPrinter(this);

    _printer.InvalidateCache();

    return _printer.BuildToString();
  }

  public string EntityName(IComponent[] components)
  {
    try
    {
      if (components.Length == 1)
        return components[0].GetType().Name;

      foreach (IComponent component in components)
      {
        switch (component.GetType().Name)
        {
          case nameof(Hero):
            return PrintHero();
          
          case nameof(Enemy):
            return PrintEnemy();          
          
          case nameof(Armament):
            return PrintArmament();
          
          case nameof(CameraComponent):
            return PrintCamera();          
          
          case nameof(Background):
            return PrintBackground();          
          
          case nameof(VegetableBoltAbility):
            return PrintVegetableBolt();      
          
          case nameof(ExplosiveEnchant):
            return PrintExplosiveEnchantComponent();      
          
          case nameof(Code.Gameplay.Audio.MusicSource):
            return PrintMusicSource();                
          
          case nameof(Code.Gameplay.Audio.SoundSource):
            return PrintSoundSource();              
          
 
        }
      }
    }
    catch (Exception exception)
    {
      Debug.LogError(exception.Message);
    }

    return components.First().GetType().Name;
  }

  private string PrintArmament()
  {
    return new StringBuilder($"Armament ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  }

  private string PrintHero()
  {
    return new StringBuilder($"Hero ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  }
  
  private string PrintEnemy() =>
    new StringBuilder($"Enemy ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();  
  
  private string PrintCamera() =>
    new StringBuilder($"Camera ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();  
  
  private string PrintBackground() =>
    new StringBuilder($"Background ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();  
  
  private string PrintVegetableBolt() =>
    new StringBuilder($"Meteor Ability")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();  
  
  private string PrintExplosiveEnchantComponent() =>
    new StringBuilder($"Explosive Enchant ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();  
  
  private string PrintMusicSource() =>
    new StringBuilder($"Music Source ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  
  private string PrintSoundSource() =>
    new StringBuilder($"Sound Source ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  
  public string BaseToString() => base.ToString();
}

