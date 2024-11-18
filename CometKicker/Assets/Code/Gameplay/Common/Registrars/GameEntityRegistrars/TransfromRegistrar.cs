using Code.Infrastructure.Views.Registrars;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class TransfromRegistrar : GameEntityComponentRegistrar
    {
       
        public override void RegisterComponents()
        {
            Entity
                .AddTransform(transform);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasTransform)
            {
                Entity
                    .RemoveTransform();
            }
        }
    }
}