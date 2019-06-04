using System;
using Fluky.Types;

namespace Fluky.DataSets
{
  public class Honorific : IEquatable<Honorific>
  {
    public Honorific()
    {
    }

    public Honorific(string name, string abbreviation, GenderType genderType, HonorificType type)
    {
      Name = name;
      Abbreviation = abbreviation;
      GenderType = genderType;
      Type = type;
    }

    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public GenderType GenderType { get; set; }
    public HonorificType Type { get; set; }

    public bool Equals(Honorific other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(Name, other.Name) && string.Equals(Abbreviation, other.Abbreviation) && GenderType == other.GenderType && Type == other.Type;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == GetType() && Equals((Honorific)obj);
    }

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