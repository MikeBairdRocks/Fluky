using Fluky.Types;

namespace Fluky
{
  public partial class Randomizer
  {
    /// <summary>
    /// Return a Random color.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="casing"></param>
    /// <param name="grayscale"></param>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string. (ex. "rgba(128, 255, 128, 0.5)")
    ///     var color = _random.Color(ColorFormat.Rgba);
    ///   </code>
    /// </example>
    /// <returns></returns>
    public string Color(ColorFormat format, CasingType casing = CasingType.Lower, bool grayscale = true)
    {
      var colorValue = "";
      switch (format)
      {
        case ColorFormat.Hex:
          colorValue = $"#{(grayscale ? Gray(Hash(2)) : Hash(6))}";
          break;
        case ColorFormat.ShortHex:
          colorValue = $"#{(grayscale ? Gray(Hash(1)) : Hash(3))}";
          break;
        case ColorFormat.Rgb:
          if (grayscale)
          {
            var rgb = Gray(Natural(max: 255).ToString(), ",");
            colorValue = $"rgb({rgb})";
          }
          else
          {
            var r = Natural(255);
            var g = Natural(255);
            var b = Natural(255);
            colorValue = $"rgb({r}, {g}, {b})";
          }
          break;
        case ColorFormat.Rgba:
          if (grayscale)
          {
            var rgb = Gray(Natural(max: 255).ToString(), ",");
            var alpha = Float(0, 1);
            colorValue = $"rgba({rgb}, {alpha})";
          }
          else
          {
            var r = Natural(255);
            var g = Natural(255);
            var b = Natural(255);
            var alpha = Float(0, 1);
            colorValue = $"rgba({r}, {g}, {b}, {alpha})";
          }
          break;
        case ColorFormat.ConstantHex:
          colorValue = $"0x{(grayscale ? Gray(Hash(2)) : Hash(6))}";
          break;
        default:
          colorValue = string.Empty;
          break;
      }

      if (casing == CasingType.Upper)
        colorValue = colorValue.ToUpper();

      return colorValue;
    }

    private string Gray(string value, string delimiter = "")
    {
      var stringArray = new[] { value, value, value };
      return string.Join(delimiter, stringArray);
    }
    //public string Domain()
    //{
    //  throw new NotImplementedException();
    //}

    //public string Email()
    //{
    //  throw new NotImplementedException();
    //}

    //public string HashTag()
    //{
    //  throw new NotImplementedException();
    //}

    //public string Ip()
    //{
    //  throw new NotImplementedException();
    //}

    //public string Ipv6()
    //{
    //  throw new NotImplementedException();
    //}

    //public string Tld()
    //{
    //  throw new NotImplementedException();
    //}

    //public string TwitterHandle()
    //{
    //  throw new NotImplementedException();
    //}

    //public string FacebookId()
    //{
    //  throw new NotImplementedException();
    //}

    //public string GoogleAnalytics()
    //{
    //  throw new NotImplementedException();
    //}
  }
}
