using Fluky.Types;

namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public class Currency
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="codeType"></param>
    /// <param name="name"></param>
    public Currency(CurrencyCodeType codeType, string name)
    {
      CodeType = codeType;
      Name = name;
    }

    /// <summary>
    /// 
    /// </summary>
    public CurrencyCodeType CodeType { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }
  }
}
