namespace Fluky.DataSets
{
  public class  StreetSuffix
  {
    public StreetSuffix(string name, string abbreviation)
    {
      Name = name;
      Abbreviation = abbreviation;
    }

    public string Name { get; set; }
    public string Abbreviation { get; set; }
  }
}
