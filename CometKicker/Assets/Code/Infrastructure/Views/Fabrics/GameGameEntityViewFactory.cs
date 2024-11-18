using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Views.Fabrics
{
    public class GameGameEntityViewFactory : IGameEntityViewFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        private readonly Vector3 _farAway = new Vector3(-999, -999, 0);

        public GameGameEntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public GameEntityBehaviour CreateViewForEntity(GameEntity entity)
        {
            GameEntityBehaviour viewPrefab = _assetProvider.LoadAsset<GameEntityBehaviour>(entity.ViewPath);
            GameEntityBehaviour view = _instantiator.InstantiatePrefabForComponent<GameEntityBehaviour>(
                viewPrefab,
                position: _farAway,
                Quaternion.identity, 
                parentTransform: null
                );
            view.SetEntity(entity);
            return view;
        }
        public GameEntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            GameEntityBehaviour view = _instantiator.InstantiatePrefabForComponent<GameEntityBehaviour>(
                entity.ViewPrefab,
                position: _farAway,
                Quaternion.identity, 
                parentTransform: null
            );
            view.SetEntity(entity);
            return view;
        }
    }
}