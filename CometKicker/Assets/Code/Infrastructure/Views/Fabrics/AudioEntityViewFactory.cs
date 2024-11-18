using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Views.AudioViews;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Views.Fabrics
{
    public class AudioEntityViewFactory : IAudioEntityViewFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        private readonly Vector3 _farAway = new Vector3(-999, -999, 0);

        public AudioEntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        public AudioEntityBehaviour CreateViewForEntity(AudioEntity entity)
        {
            AudioEntityBehaviour viewPrefab = _assetProvider.LoadAsset<AudioEntityBehaviour>(entity.ViewPath);
            AudioEntityBehaviour view = _instantiator.InstantiatePrefabForComponent<AudioEntityBehaviour>(
                viewPrefab,
                position: _farAway,
                Quaternion.identity, 
                parentTransform: null
            );
            view.SetEntity(entity);
            return view;
        }

        public AudioEntityBehaviour CreateViewForEntityFromPrefab(AudioEntity entity)
        {
            AudioEntityBehaviour view = _instantiator.InstantiatePrefabForComponent<AudioEntityBehaviour>(
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