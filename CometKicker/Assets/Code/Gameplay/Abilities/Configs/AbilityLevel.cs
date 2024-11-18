using System;
using System.Collections.Generic;
using Code.Common;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class AbilityLevel
  {
    public Sprite Icon;
    public string Description;
    
    public float Cooldown;

    public GameEntityBehaviour ViewPrefab;
    public GameEntityBehaviour CollisionEffectPrefab;

    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;
    
    public ProjectileSetup ProjectileSetup;
    public AuraSetup AuraSetup;
  }
}