namespace Code.Infrastructure.Views.Registrars
{
    public abstract class GameEntityComponentRegistrar: GameEntityDependent, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnRegisterComponents();
    }
}