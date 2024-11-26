using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using RSG;
using UnityEngine;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class EndOfFrameExitState : IState, IUpdateable
    {
        private UniTaskCompletionSource<bool> _exitCompletionSource;

        protected bool ExitWasRequested =>
            _exitCompletionSource != null;

        public virtual void Enter()
        {
        }

        public UniTask BeginExitAsync()
        {
            _exitCompletionSource = new UniTaskCompletionSource<bool>();
            return _exitCompletionSource.Task.AsUniTask();
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
            UniTask.Run(async () =>
            {
                await UniTask.Yield();
                ResolveExitTask();
            });
        }

        protected virtual void OnUpdate() { }

        private void ClearExitCompletionSource() =>
            _exitCompletionSource = null;

        private void ResolveExitTask()
        {
            if (_exitCompletionSource != null && !_exitCompletionSource.Task.Status.IsCompleted())
                _exitCompletionSource.TrySetResult(true);
        }
    }
}