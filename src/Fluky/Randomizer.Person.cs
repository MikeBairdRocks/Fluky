using System;
using System.Linq;
using System.Text.RegularExpressions;
using Fluky.Extensions;
using Fluky.Types;

namespace Fluky
{
  public partial class Randomizer
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public int Age(AgeType type = AgeType.Any)
    {
      int age;

      switch (type)
      {
        case AgeType.Child:
          age = Natural(1, 12);
          break;
        case AgeType.Teen:
          age = Natural(13, 19);
          break;
        case AgeType.Adult:
          age = Natural(18, 120);
          break;
        case AgeType.Senior:
          age = Natural(65, 120);
          break;
        default:
          age = Natural(1, 120);
          break;
      }

      return age;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public DateTime Birthday(AgeType type = AgeType.Any)
    {
      var age = Age(type);
      var year = DateTime.Now.Year - age;

      return Date(year);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="genderType"></param>
    /// <returns></returns>
    public string FirstName(GenderType genderType = GenderType.Any)
    {
      var firstNames = _data.FirstNames.ToList();
      if (genderType != GenderType.Any)
        return Pick(firstNames.Where(x => x.GenderType == genderType).ToList()).Name;

      return Pick(firstNames).Name;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public GenderType Gender()
    {
      var genders = EnumExtensions.GetEnumValues<GenderType>().ToList();
      return Pick(genders);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string LastName()
    {
      var lastNames = _data.LastNames.ToList();
      return Pick(lastNames);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="genderType"></param>
    /// <param name="prefix"></param>
    /// <param name="middle"></param>
    /// <param name="middleInitial"></param>
    /// <returns></returns>
    public string Name(GenderType genderType = GenderType.Any, bool prefix = false, bool middle = false, bool middleInitial = false)
    {
      var firstName = FirstName(genderType);
      var lastName = LastName();
      string name;

      if (middle)
        name = string.Format("{0} {1} {2}", firstName, FirstName(genderType), lastName);
      else if (middleInitial)
        name = string.Format("{0} {1}. {2}", firstName, Character(alpha: true, casing: CasingType.Upper), lastName);
      else
        name = string.Format("{0} {1}", firstName, lastName);

      return name;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="genderType"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public Honorific Honorific(GenderType genderType = GenderType.Any, HonorificType type = HonorificType.Any)
    {
      var honorifics = _data.Honorifics.ToList();

      if (genderType != GenderType.Any)
        honorifics = honorifics.Where(x => x.GenderType == genderType).ToList();

      if (type != HonorificType.Any)
        honorifics = honorifics.Where(x => x.Type == type).ToList();

      return Pick(honorifics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ssnFour"></param>
    /// <param name="dashes"></param>
    /// <param name="masked"></param>
    /// <returns></returns>
    public string Ssn(bool ssnFour = false, bool dashes = false, bool masked = false)
    {
      const string ssnPool = "1234567890";
      var dash = dashes ? "-" : "";

      if (!ssnFour)
      {
        var ssn = string.Format("{0}{1}{2}{1}{3}", String(pool: ssnPool, length: 3), dash, String(pool: ssnPool, length: 2), String(pool: ssnPool, length: 4));

        if (!masked) 
          return ssn;

        const string pattern = @"(?:\d{3})-(?:\d{2})-(\d{4})";
        return Regex.Replace(ssn, pattern, "$1-XX-XXXX");
      }

      return String(pool: ssnPool, length: 4);
    }
  }
}
