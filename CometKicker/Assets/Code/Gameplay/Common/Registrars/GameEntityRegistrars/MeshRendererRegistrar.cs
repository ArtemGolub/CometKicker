using Code.Infrastructure.Views.Registrars;
using UnityEngine;

public class MeshRendererRegistrar : GameEntityComponentRegistrar
{
    public MeshRenderer MeshRenderer;
    
    public override void RegisterComponents()
    {
        Entity
            .AddMeshRenderer(MeshRenderer);
    }

    public override void UnRegisterComponents()
    {
        if (Entity.hasMeshRenderer)
        {
            Entity
                .RemoveMeshRenderer();
        }
    }
}
