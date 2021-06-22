using Fluky.Types;

namespace Fluky.DataSets
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

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string ShortName { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public CreditCardType Type { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Prefix { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int Length { get; set; }
  }
}