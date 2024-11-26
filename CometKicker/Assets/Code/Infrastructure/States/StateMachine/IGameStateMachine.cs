using System.Threading.Tasks;
using Code.Infrastructure.States.StateInfrastructure;
using Cysharp.Threading.Tasks;


namespace Code.Infrastructure.States.StateMachine
{
  public interface IGameStateMachine 
  {
    UniTask Enter<TState>() where TState : class, IState;
    UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    bool CompareState<TState>() where TState : class, IState;
  }
}