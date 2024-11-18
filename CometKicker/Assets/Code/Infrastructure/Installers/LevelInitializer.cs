using Code.Gameplay.Cameras;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField]private Transform StartPoint;
        private ICameraProvider _cameraProvider;
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(
            ICameraProvider cameraProvider, 
            ILevelDataProvider levelDataProvider
        )
        {
            _levelDataProvider = levelDataProvider;
            _cameraProvider = cameraProvider;
        }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(StartPoint.position);

        }
    }
}