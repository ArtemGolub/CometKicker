using System.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class SimpleState : IState
    {
        public virtual void Enter()
        {
        }

        protected virtual void Exit()
        {
        }

        async Task IExitableState.BeginExitAsync()
        {
            Exit();
            await Task.CompletedTask; // Асинхронная совместимость, завершённая задача
        }

        void IExitableState.EndExit()
        {
        }
    }
}