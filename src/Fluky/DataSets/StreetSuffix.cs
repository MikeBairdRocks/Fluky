namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public class  StreetSuffix
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="abbreviation"></param>
    public StreetSuffix(string name, string abbreviation)
    {
      Name = name;
      Abbreviation = abbreviation;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Abbreviation { get; set; }
  }
}