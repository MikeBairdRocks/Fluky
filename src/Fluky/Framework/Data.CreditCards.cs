using System.Collections.Generic;
using Fluky.Core.Models;

namespace Fluky.Framework
{
  public partial class Data
  {
    private IEnumerable<CreditCard> _creditCards;

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<CreditCard> CreditCards
    {
      get
      {
        if (_creditCards != null)
          return _creditCards;

        return new List<CreditCard>
        {
          new CreditCard("American Express", "amex", CreditCardType.AmericanExpress, "34", 15),
          new CreditCard("Bankcard", "bankcard", CreditCardType.Bankcard, "5610", 16),
          new CreditCard("China UnionPay", "chinaunion", CreditCardType.ChinaUnionPay, "62", 16),
          new CreditCard("Diners Club Carte Blanche", "dccarte", CreditCardType.DinersClubCarteBlanche, "300", 14),
          new CreditCard("Diners Club enRoute", "dcenroute", CreditCardType.DinersClubenRoute, "2014", 15),
          new CreditCard("Diners Club International", "dcintl", CreditCardType.DinersClubInternational, "36", 14),
          new CreditCard("Diners Club United States & Canada", "dcusc", CreditCardType.DinersClubUnitedStatesCanada, "54", 16),
          new CreditCard("Discover Card", "discover", CreditCardType.Discover, "6011", 16),
          new CreditCard("InstaPayment", "instapay", CreditCardType.InstaPayment, "637", 16),
          new CreditCard("JCB", "jcb", CreditCardType.JCB, "3528", 16),
          new CreditCard("Laser", "laser", CreditCardType.Laser, "6304", 16),
          new CreditCard("Maestro", "maestro", CreditCardType.Maestro, "5018", 16),
          new CreditCard("Mastercard", "mc", CreditCardType.Mastercard, "51", 16),
          new CreditCard("Solo", "solo", CreditCardType.Solo, "6334", 16),
          new CreditCard("Switch", "switch", CreditCardType.Switch, "4903", 16),
          new CreditCard("Visa", "visa", CreditCardType.Visa, "4", 16),
          new CreditCard("Visa Electron", "electron", CreditCardType.VisaElectron, "4026", 16)
        };
      }
      set { _creditCards = value; }
    }
  }
}
