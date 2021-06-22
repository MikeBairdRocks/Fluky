using System;
using Fluky.Types;

namespace Fluky.DataSets
{
  /// <summary>
  /// 
  /// </summary>
  public class Honorific : IEquatable<Honorific>
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="abbreviation"></param>
    /// <param name="genderType"></param>
    /// <param name="type"></param>
    public Honorific(string name, string abbreviation, GenderType genderType, HonorificType type)
    {
      Name = name;
      Abbreviation = abbreviation;
      GenderType = genderType;
      Type = type;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Abbreviation { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public GenderType GenderType { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public HonorificType Type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Honorific other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(Name, other.Name) && string.Equals(Abbreviation, other.Abbreviation) && GenderType == other.GenderType && Type == other.Type;
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
      return obj.GetType() == GetType() && Equals((Honorific)obj);
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
        hashCode = (hashCode * 397) ^ (Abbreviation?.GetHashCode() ?? 0);
        hashCode = (hashCode * 397) ^ (int)GenderType;
        hashCode = (hashCode * 397) ^ (int)Type;
        return hashCode;
      }
    }
  }
}