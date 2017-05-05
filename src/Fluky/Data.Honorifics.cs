using System.Collections.Generic;
using Fluky.Types;

namespace Fluky
{
  public partial class Data
  {
    private IEnumerable<Honorific> _honorifics;

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Honorific> Honorifics
    {
      get
      {
        if (_honorifics != null)
          return _honorifics;

        return new List<Honorific>
        {
          new Honorific("Mister", "Mr.", GenderType.Male, HonorificType.Common),
          new Honorific("Master", "Mstr.", GenderType.Male, HonorificType.Common),
          new Honorific("Ms", "Ms.", GenderType.Female, HonorificType.Common),
          new Honorific("Miss", "Miss", GenderType.Female, HonorificType.Common),
          new Honorific("Misses", "Mrs.", GenderType.Female, HonorificType.Common),

          new Honorific("Sir", "Sir", GenderType.Male, HonorificType.Formal),
          new Honorific("Madam", "Mme", GenderType.Female, HonorificType.Formal),
          new Honorific("Ma'am", "Mme", GenderType.Female, HonorificType.Formal),
          new Honorific("Lord", "Lord", GenderType.Female, HonorificType.Formal),
          new Honorific("Lady", "Lady", GenderType.Female, HonorificType.Formal),

          new Honorific("Doctor", "Dr.", GenderType.Male, HonorificType.Professor),
          new Honorific("Doctor", "Dr.", GenderType.Female, HonorificType.Professor),
          new Honorific("Professor", "Prof.", GenderType.Male, HonorificType.Professor),
          new Honorific("Professor", "Prof.", GenderType.Female, HonorificType.Professor),

          new Honorific("Brother", "Br.", GenderType.Male, HonorificType.Religious),
          new Honorific("Sister", "Sr.", GenderType.Female, HonorificType.Religious),
          new Honorific("Father", "Fr.", GenderType.Male, HonorificType.Religious),
          new Honorific("Reverend", "Rev.", GenderType.Male, HonorificType.Religious),
          new Honorific("Pastor", "Pr.", GenderType.Male, HonorificType.Religious),
          new Honorific("Elder", "Elder", GenderType.Male, HonorificType.Religious),
        };
      }
      set => _honorifics = value;
    }
  }
}
