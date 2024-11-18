using Code.Gameplay.Cheats.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Cheats
{
    public class CheatsFeature: Feature
    {
        public CheatsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RestoreHeroHpByButtonSystem>());
        }
    }
}