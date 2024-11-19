using System.Threading.Tasks;

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

        async Task IExitableState.BeginExitAsync()
        {
            Exit();
            await Task.CompletedTask;
        }

        void IExitableState.EndExit()
        {
        }
    }
}