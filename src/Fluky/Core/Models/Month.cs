namespace Fluky.Core.Models
{
  public class Month
  {
    public Month()
    {
    }

    public Month(string name, string shortName, int numeric)
    {
      Name = name;
      ShortName = shortName;
      Numeric = numeric;
    }

    public string Name { get; private set; }
    public string ShortName { get; private set; }
    public int Numeric { get; private set; }
  }
}