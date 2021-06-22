namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public class State
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="abbreviation"></param>
    public State(string name, string abbreviation)
    {
      Name = name;
      Abbreviation = abbreviation;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Abbreviation { get; }
  }
}