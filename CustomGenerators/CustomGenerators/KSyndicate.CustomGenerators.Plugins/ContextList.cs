using System.Collections.Generic;
using System.Linq;

namespace External.CustomGenerators.Plugins
{
  public class ContextList
  {
    public List<string> ContextNames { get; }

    public ContextList(IEnumerable<string> contextNames)
    {
      ContextNames = contextNames.ToList();
    }
  }
}