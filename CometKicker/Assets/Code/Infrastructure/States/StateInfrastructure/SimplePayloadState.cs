using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class SimplePayloadState<TPayload> : IPayloadState<TPayload>
    {
        public virtual void Enter(TPayload payload)
        {
        }

        protected virtual void Exit()
        {
        }

        async UniTask IExitableState.BeginExitAsync()
        {
            Exit();
            await UniTask.CompletedTask;
        }

        void IExitableState.EndExit()
        {
        }
    }
}