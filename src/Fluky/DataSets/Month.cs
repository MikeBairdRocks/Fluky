using System;

namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public class Month : IEquatable<Month>
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="shortName"></param>
    /// <param name="numeric"></param>
    public Month(string name, string shortName, int numeric)
    {
      Name = name;
      ShortName = shortName;
      Numeric = numeric;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public string ShortName { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public int Numeric { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Month other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(Name, other.Name) && string.Equals(ShortName, other.ShortName) && Numeric == other.Numeric;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == GetType() && Equals((Month) obj);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = Name?.GetHashCode() ?? 0;
        hashCode = (hashCode * 397) ^ (ShortName?.GetHashCode() ?? 0);
        hashCode = (hashCode * 397) ^ Numeric;
        return hashCode;
      }
    }
  }
}