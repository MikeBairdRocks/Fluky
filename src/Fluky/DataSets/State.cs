namespace Fluky.DataSets
{
  public class State
  {
    public State(string name, string abbreviation)
    {
      Name = name;
      Abbreviation = abbreviation;
    }

    public string Name { get; }
    public string Abbreviation { get; }
  }
}