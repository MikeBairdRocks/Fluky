using System.Collections.Generic;
using Fluky.Core.Models;

namespace Fluky.Framework
{
  public partial class Data
  {
    private IEnumerable<State> _armedForces;

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<State> ArmedForces
    {
      get
      {
        if (_armedForces != null)
          return _armedForces;

        return new List<State>
        {
          new State("Armed Forces Europe", "AE"),
          new State("Armed Forces Pacific", "AP"),
          new State("Armed Forces the Americas", "AA")
        };
      }
      set { _armedForces = value; }
    }
  }
}