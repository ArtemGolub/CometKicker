using Code.Infrastructure.Views.AudioViews;

namespace Code.Infrastructure.Views.Fabrics
{
    public interface IAudioEntityViewFactory
    {
        AudioEntityBehaviour CreateViewForEntity(AudioEntity entity);
        AudioEntityBehaviour CreateViewForEntityFromPrefab(AudioEntity entity);
    }
}