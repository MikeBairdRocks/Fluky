using System.Collections.Generic;
using Fluky.Core.Models;

namespace Fluky.Framework
{
  public interface IData
  {
    IEnumerable<State> Territories { get; set; }
    IEnumerable<Honorific> Honorifics { get; set; }
    IEnumerable<FirstName> FirstNames { get; set; }
    IEnumerable<Currency> Currencies { get; set; }
    IEnumerable<CreditCard> CreditCards { get; set; }
    IEnumerable<State> ArmedForces { get; set; }
    IEnumerable<StreetSuffix> StreetSuffixes { get; set; }
    IEnumerable<State> States { get; set; }
    IEnumerable<Province> Provinces { get; set; }
    IEnumerable<string> LastNames { get; set; }
  }
}