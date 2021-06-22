using System.Collections.Generic;

namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public interface IData
  {
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<State> Territories { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Honorific> Honorifics { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<FirstName> FirstNames { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Currency> Currencies { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<CreditCard> CreditCards { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<State> ArmedForces { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<StreetSuffix> StreetSuffixes { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<State> States { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Province> Provinces { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<string> LastNames { get; set; }
  }
}