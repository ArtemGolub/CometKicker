using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
  public interface IExitableState
  {
    UniTask BeginExitAsync();
    void EndExit();
  }
}