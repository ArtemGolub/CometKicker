using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Infrastructure.Views
{
    public abstract class GameEntityDependent : MonoBehaviour
    {
        [FormerlySerializedAs("EntityView")] public GameEntityBehaviour gameEntityView;
        public GameEntity Entity => gameEntityView != null ? gameEntityView.Entity : null;

        private void Awake()
        {
            if (!gameEntityView)
                gameEntityView = GetComponent<GameEntityBehaviour>();
        }

    }    

}