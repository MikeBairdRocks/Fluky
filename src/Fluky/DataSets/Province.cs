namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public class Province
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="abbreviation"></param>
    public Province(string name, string abbreviation)
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