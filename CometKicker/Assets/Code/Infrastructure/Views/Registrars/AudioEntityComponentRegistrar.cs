using Code.Infrastructure.Views.AudioViews;

namespace Code.Infrastructure.Views.Registrars
{
    public abstract class AudioEntityComponentRegistrar: AudioEntityDependent, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnRegisterComponents();
    }
}