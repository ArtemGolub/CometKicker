using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [CreateAssetMenu(menuName = "Custom", fileName = "abilityConfig")]
  public class AbilityConfig : ScriptableObject
  {
    public AbilityId AbilityId;
    public List<AbilityLevel> Levels;
  }
}