using Code.Gameplay.Cameras;
using Code.Infrastructure.Views.Registrars;
using UnityEngine;
using Zenject;

public class CameraRegistrar : GameEntityComponentRegistrar
{
    public Camera Camera;
    private ICameraProvider _cameraProvider;

    [Inject]
    private void Construct(
        ICameraProvider cameraProvider
    )
    {
        _cameraProvider = cameraProvider;
    }
    
    public override void RegisterComponents()
    {
        Entity
            .AddCamera(Camera);
        _cameraProvider.SetMainCamera(Camera);
    }

    public override void UnRegisterComponents()
    {
        if (Entity.hasCamera)
        {
            Entity
                .RemoveCamera();
        }
    }
}
