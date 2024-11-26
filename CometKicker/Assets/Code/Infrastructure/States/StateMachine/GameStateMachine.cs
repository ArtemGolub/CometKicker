using System;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateInfrastructure;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.States.StateMachine
{
    public class GameStateMachine : IGameStateMachine, ITickable
    {
        private IExitableState _activeState;
        private readonly IStateFactory _stateFactory;
        private Type _activeStateType;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
            {
                updateableState.Update();
            }
        }

        public async UniTask Enter<TState>() where TState : class, IState
        {
            await RequestEnter<TState>();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            await RequestEnter<TState, TPayload>(payload);
        }
        

        public bool CompareState<TState>() where TState : class, IState
        {
            return _activeStateType == typeof(TState);
        }

        private async UniTask<TState> RequestEnter<TState>() where TState : class, IState
        {
            var state = await RequestChangeState<TState>();
            EnterState(state);
            return state;
        }

        private async UniTask<TState> RequestEnter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = await RequestChangeState<TState>();
            EnterPayloadState(state, payload);
            return state;
        }

        private void EnterState<TState>(TState state) where TState : class, IState
        {
            _activeState = state;
            _activeStateType = typeof(TState);
            state.Enter();
        }

        private void EnterPayloadState<TState, TPayload>(TState state, TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            _activeState = state;
            state.Enter(payload);
        }

        private async UniTask<TState> RequestChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
            {
                try
                {
                    await _activeState.BeginExitAsync();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error during state exit: {e.Message}");
                }
                _activeState.EndExit();
            }
            return ChangeState<TState>();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            var state = _stateFactory.GetState<TState>();
            if (state == null)
                Debug.LogError($"State of type {typeof(TState)} not found!");
            return state;
        }
    }
}
