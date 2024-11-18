namespace Code.Infrastructure.Views.Fabrics
{
    public interface IGameEntityViewFactory
    {
        GameEntityBehaviour CreateViewForEntity(GameEntity entity);
        GameEntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    }
}