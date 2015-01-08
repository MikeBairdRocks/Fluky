namespace Fluky.Core.Models
{
  public class Honorific
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
  }
}