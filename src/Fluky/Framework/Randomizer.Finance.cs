using System;
using System.Globalization;
using System.Linq;
using Fluky.Core.Extensions;
using Fluky.Core.Models;

namespace Fluky.Framework
{
  public partial class Randomizer
  {
    /// <summary>
    /// Generate a random credit card number. This card number will pass the Luhn algorithm so it looks like a legit card.
    /// </summary>
    /// <param name="ccType"></param>
    /// <returns></returns>
    public string CreditCardNumber(CreditCardType? ccType = null)
    {
      var card = ccType.HasValue ? CreditCard(ccType) : CreditCard();
      var toGenerate = card.Length - card.Prefix.Length - 1;

      // Generates n - 1 digits
      var number = Enumerable.Concat(card.Prefix, Integer(toGenerate, toGenerate).ToString(CultureInfo.InvariantCulture));

      // Generates the last digit according to Luhn algorithm
      number = string.Format("{0}{1}", number, LuhnAlgorithm(number.ToString()));

      return number.ToString();
    }

    /// <summary>
    /// Generate a random credit card number. This card number will pass the Luhn algorithm so it looks like a legit card.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public CreditCard CreditCard(CreditCardType? type = null)
    {
      var list = _data.CreditCards.ToList();

      return type.HasValue ? list.FirstOrDefault(x => x.Type == type.Value) : Pick(list);
    }

    /// <summary>
    /// Generate a random currency.
    /// </summary>
    /// <returns></returns>
    public Currency Currency()
    {
      var list = _data.Currencies.ToList();
      return Pick(list);
    }

    /// <summary>
    /// Return a random dollar amount.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public string Dollar(int min = 0, int max = 10000)
    {
      min.ThrowIfGreaterThan(max);

      var dollar = Decimal(min, max, 2).ToString(CultureInfo.InvariantCulture);
      var cents = dollar.Split('.')[1];

      if (cents == null)
        dollar += ".00";
      else
        dollar = string.Format("{0}0", dollar);

      if (decimal.Parse(dollar) < 0)
        return string.Format("-${0}", dollar.Replace("-", ""));

      return string.Format("${0}", dollar);
    }

    /// <summary>
    /// Generate a random credit card expiration date.
    /// </summary>
    /// <param name="future"></param>
    /// <returns></returns>
    public string Expiration(bool future = true)
    {
      var year = ExpirationYear(future);
      int month;

      // If the year is this year, need to ensure month is greater than the current month or this expiration will not be valid
      if (year == (DateTime.UtcNow.Year))
      {
        month = ExpirationMonth(true);
      }
      else
      {
        month = ExpirationMonth(false);
      }

      return string.Format("{0}/{1}", month, year);
    }

    /// <summary>
    /// Generate a random credit card expiration month.
    /// </summary>
    /// <param name="future"></param>
    /// <returns></returns>
    public int ExpirationMonth(bool future = true)
    {
      int month;
      var curMonth = DateTime.UtcNow.Month;

      if (future)
      {
        int monthInt;
        do
        {
          month = Month().Numeric;
          monthInt = month;
        } while (monthInt < curMonth);
      }
      else
      {
        month = Month().Numeric;
      }

      return month;
    }

    /// <summary>
    /// Generate a random credit card expiration year.
    /// </summary>
    /// <param name="future"></param>
    /// <returns></returns>
    public int ExpirationYear(bool future = true)
    {
      var now = DateTime.UtcNow;
      var min = future ? now.Year : now.AddYears(-10).Year;
      var max = future ? now.AddYears(10).Year : now.AddYears(-1).Year;

      return Year(min, max);
    }

    private string LuhnAlgorithm(string number)
    {
      var sum = 0;
      var alt = true;
      var digits = number.ToCharArray();

      for (var i = digits.Length - 1; i >= 0; i--)
      {
        var curDigit = (digits[i] - 48);
        if (alt)
        {
          curDigit *= 2;
          if (curDigit > 9)
            curDigit -= 9;
        }
        sum += curDigit;
        alt = !alt;
      }

      return (sum % 10) == 0 ? "0" : (10 - (sum % 10)).ToString(CultureInfo.InvariantCulture);
    }
  }
}
