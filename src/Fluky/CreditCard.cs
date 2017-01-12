using Fluky.Types;

namespace Fluky
{
  /// <summary>
  /// 
  /// </summary>
  public class CreditCard
  {
    /// <summary>
    /// 
    /// </summary>
    public CreditCard()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="shortName"></param>
    /// <param name="type"></param>
    /// <param name="prefix"></param>
    /// <param name="length"></param>
    public CreditCard(string name, string shortName, CreditCardType type, string prefix, int length)
    {
      Name = name;
      ShortName = shortName;
      Type = type;
      Prefix = prefix;
      Length = length;
    }

    public string Name { get; set; }
    public string ShortName { get; set; }
    public CreditCardType Type { get; set; }
    public string Prefix { get; set; }
    public int Length { get; set; }
  }
}