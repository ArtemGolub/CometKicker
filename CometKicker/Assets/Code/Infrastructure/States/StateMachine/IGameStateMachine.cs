using System.Threading.Tasks;
using Code.Infrastructure.States.StateInfrastructure;


namespace Code.Infrastructure.States.StateMachine
{
  public interface IGameStateMachine 
  {
    Task Enter<TState>() where TState : class, IState;
    Task Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    bool CompareState<TState>() where TState : class, IState;
  }
}