namespace Fluky.Core.Models
{
  public class Province
  {
    public Province()
    {
    }

    public Province(string name, string abbreviation)
    {
      Name = name;
      Abbreviation = abbreviation;
    }

    public string Name { get; set; }
    public string Abbreviation { get; set; }
  }
}