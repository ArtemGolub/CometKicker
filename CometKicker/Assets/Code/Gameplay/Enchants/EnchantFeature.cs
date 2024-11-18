using Code.Gameplay.Features.Enchants.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enchants
{
  public sealed class EnchantFeature : Feature
  {
    public EnchantFeature(ISystemFactory systems)
    {
      Add(systems.Create<ExplosiveEnchantSystem>());
    }
  }
}