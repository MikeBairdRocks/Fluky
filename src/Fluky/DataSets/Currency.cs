using Fluky.Types;

namespace Fluky.DataSets
{
  public class Currency
  {
    public Currency(CurrencyCodeType codeType, string name)
    {
      CodeType = codeType;
      Name = name;
    }

    public CurrencyCodeType CodeType { get; }
    public string Name { get; }
  }
}
