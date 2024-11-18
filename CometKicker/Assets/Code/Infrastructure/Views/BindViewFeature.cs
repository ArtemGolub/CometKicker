using Code.Infrastructure.Systems;
using Code.Infrastructure.Views.Systems;

namespace Code.Infrastructure.Views
{
    public sealed class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindEntityViewFromPathSystem>());
            Add(systems.Create<BindEntityViewFromPrefabSystem>());
            
            Add(systems.Create<BindAudioEntityViewFromPathSystem>());
            Add(systems.Create<BindAudioEntityViewFromPrefabSystem>());
        }
    }
}