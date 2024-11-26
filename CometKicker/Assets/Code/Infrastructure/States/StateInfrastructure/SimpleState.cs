using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

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

        UniTask IExitableState.BeginExitAsync()
        {
            Exit();
            return UniTask.CompletedTask;
        }

        void IExitableState.EndExit()
        {
        }
    }
}