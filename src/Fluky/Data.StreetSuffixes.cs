using System.Collections.Generic;

namespace Fluky
{
  public partial class Data
  {
    private IEnumerable<StreetSuffix> _streetSuffixes;

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<StreetSuffix> StreetSuffixes
    {
      get
      {
        if (_streetSuffixes != null)
          return _streetSuffixes;
        return new List<StreetSuffix>
        {
          new StreetSuffix("Avenue", "Ave"),
          new StreetSuffix("Boulevard", "Blvd"),
          new StreetSuffix("Center", "Ctr"),
          new StreetSuffix("Circle", "Cir"),
          new StreetSuffix("Court", "Ct"),
          new StreetSuffix("Drive", "Dr"),
          new StreetSuffix("Extension", "Ext"),
          new StreetSuffix("Glen", "Gln"),
          new StreetSuffix("Grove", "Grv"),
          new StreetSuffix("Heights", "Hts"),
          new StreetSuffix("Highway", "Hwy"),
          new StreetSuffix("Junction", "Jct"),
          new StreetSuffix("Key", "Key"),
          new StreetSuffix("Lane", "Ln"),
          new StreetSuffix("Loop", "Loop"),
          new StreetSuffix("Manor", "Mnr"),
          new StreetSuffix("Mill", "Mill"),
          new StreetSuffix("Park", "Park"),
          new StreetSuffix("Parkway", "Pkwy"),
          new StreetSuffix("Pass", "Pass"),
          new StreetSuffix("Path", "Path"),
          new StreetSuffix("Pike", "Pike"),
          new StreetSuffix("Place", "Pl"),
          new StreetSuffix("Plaza", "Plz"),
          new StreetSuffix("Point", "Pt"),
          new StreetSuffix("Ridge", "Rdg"),
          new StreetSuffix("River", "Riv"),
          new StreetSuffix("Road", "Rd"),
          new StreetSuffix("Square", "Sq"),
          new StreetSuffix("Street", "St"),
          new StreetSuffix("Terrace", "Ter"),
          new StreetSuffix("Trail", "Trl"),
          new StreetSuffix("Turnpike", "Tpke"),
          new StreetSuffix("View", "Vw"),
          new StreetSuffix("Way", "Way")
        };
      }

      set { _streetSuffixes = value; }
    }
  }
}
