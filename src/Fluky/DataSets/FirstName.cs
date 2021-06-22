using Fluky.Types;

namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public class FirstName
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="genderType"></param>
    public FirstName(string name, GenderType genderType)
    {
      Name = name;
      GenderType = genderType;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public GenderType GenderType { get; set; }
  }
}
