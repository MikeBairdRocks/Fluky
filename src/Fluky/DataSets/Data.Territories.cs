using System.Collections.Generic;

namespace Fluky.DataSets
{
  public partial class Data
  {
    private IEnumerable<State> _territories;

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<State> Territories
    {
      get
      {
        if (_territories != null)
          return _territories;

        return new List<State>
        {
          new State("American Samoa", "AS"),
          new State("Federated States of Micronesia", "FM"),
          new State("Guam", "GU"),
          new State("Marshall Islands", "MH"),
          new State("Northern Mariana Islands", "MP"),
          new State("Puerto Rico", "PR"),
          new State("Virgin Islands, U.S.", "VI")
        };
      }

      set { _territories = value; }
    }
  }
}
