using UnityEngine;

namespace Code.Infrastructure.Views.AudioViews
{
    public interface IEntityAudioView
    {
        AudioEntity Entity { get; }
        void SetEntity(AudioEntity entity);
        void ReleaseEntity();

        GameObject gameObject { get; }
    }
}