using System.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
  public interface IExitableState
  {
    Task BeginExitAsync();
    void EndExit();
  }
}