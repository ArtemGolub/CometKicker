using Code.Infrastructure.Views;
using Code.Infrastructure.Views.AudioViews;
using Entitas;

namespace Code.Common
{
    [Game, Audio] public class Destructed : IComponent { }
    [Game] public class View : IComponent { public IEntityView Value; }
    [Game] public class ViewPath : IComponent { public string Value; }
    [Game] public class ViewPrefab : IComponent { public GameEntityBehaviour Value; }
    [Game] public class SelfDestructTimer : IComponent { public float Value; }
    [Game] public class PersistentComponent : IComponent { }

}