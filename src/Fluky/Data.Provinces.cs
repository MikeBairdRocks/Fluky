using System.Collections.Generic;

namespace Fluky
{
  public partial class Data
  {
    private IEnumerable<Province> _provinces;

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Province> Provinces
    {
      get
      {
        if (_provinces != null)
          return _provinces;

        return new List<Province>
        {
          new Province("Alberta", "AB"),
          new Province("British Columbia", "BC"),
          new Province("Manitoba", "MB"),
          new Province("New Brunswick", "NB"),
          new Province("Newfoundland and Labrador", "NL"),
          new Province("Nova Scotia", "NS"),
          new Province("Ontario", "ON"),
          new Province("Prince Edward Island", "PE"),
          new Province("Quebec", "QC"),
          new Province("Saskatchewan", "SK"),

          // The case could be made that the following are not actually provinces
          // since they are technically considered "territories" however they all
          // look the same on an envelope!
          new Province("Northwest Territories", "NT"),
          new Province("Nunavut", "NU"),
          new Province("Yukon", "YT")
        };
      }
      set => _provinces = value;
    }
  }
}
