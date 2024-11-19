using System.Threading.Tasks;
using RSG;
using UnityEngine;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class EndOfFrameExitState : IState, IUpdateable
    {
        private TaskCompletionSource<bool> _exitCompletionSource;

        protected bool ExitWasRequested =>
            _exitCompletionSource != null;

        public virtual void Enter()
        {
        }

        public Task BeginExitAsync()
        {
            _exitCompletionSource = new TaskCompletionSource<bool>();
            return _exitCompletionSource.Task;
        }



        public void EndExit()
        {
            ExitOnEndOfFrame();
            ClearExitCompletionSource();
        }

        public void Update()
        {
            if (!ExitWasRequested)
                OnUpdate();

            if (ExitWasRequested)
                ResolveExitTask();
        }

        protected virtual void ExitOnEndOfFrame()
        {
            Task.Run(async () =>
            {
                await Task.Yield();
                ResolveExitTask();
            });
        }

        protected virtual void OnUpdate() { }

        private void ClearExitCompletionSource() =>
            _exitCompletionSource = null;

        private void ResolveExitTask()
        {
            if (_exitCompletionSource != null && !_exitCompletionSource.Task.IsCompleted)
                _exitCompletionSource.SetResult(true);
        }
    }
}