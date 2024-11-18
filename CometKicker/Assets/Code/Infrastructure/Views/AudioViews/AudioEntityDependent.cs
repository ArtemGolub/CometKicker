using UnityEngine;

namespace Code.Infrastructure.Views.AudioViews
{
    public abstract class AudioEntityDependent: MonoBehaviour
    {
        public AudioEntityBehaviour EntityView;
        protected AudioEntity Entity => EntityView != null ? EntityView.Entity : null;

        private void Awake()
        {
            if (!EntityView)
                EntityView = GetComponent<AudioEntityBehaviour>();
        }
    }
}