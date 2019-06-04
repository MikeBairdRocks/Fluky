namespace Fluky.DataSets
{
  /// <summary>
  /// List of constants used throughout the Fluky framework.
  /// </summary>
  public static class Constants
  {
    /// <summary>
    /// 
    /// </summary>
    public const int MinLatitude = -90;

    /// <summary>
    /// 
    /// </summary>
    public const int MaxLatitude = 90;

    /// <summary>
    /// 
    /// </summary>
    public const int MinLongitude = -180;

    /// <summary>
    /// 
    /// </summary>
    public const int MaxLongitude = 180;

    /// <summary>
    /// 
    /// </summary>
    public const int MinAltitude = 0;

    /// <summary>
    /// 
    /// </summary>
    public const int MaxAltitude = 32736000;

    /// <summary>
    /// Min depth used for Depth() method default min value.
    /// </summary>
    public const int MinDepth = -35994;

    /// <summary>
    /// Max depth used for Depth() method default max value.
    /// </summary>
    public const int MaxDepth = 0;

    /// <summary>
    /// Numbers.
    /// </summary>
    public const string Numbers = "0123456789";

    /// <summary>
    /// Characters upper lowercase.
    /// </summary>
    public const string CharsLower = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// Characters upper case.
    /// </summary>
    public static readonly string CharsUpper = CharsLower.ToUpper();

    /// <summary>
    /// String pool alpha lower and upper case.
    /// </summary>
    public const string DefaultStringPool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    /// <summary>
    /// Hex pool with some letters and numbers.
    /// </summary>
    public const string HexPool = Numbers + "abcdef";

    /// <summary>
    /// Consonants except hard to speak ones.
    /// </summary>
    public const string Consonants = "bcdfghjklmnprstvwz";

    /// <summary>
    /// Vowels in the english alphabet.
    /// </summary>
    public const string Vowels = "aeiou";

    /// <summary>
    /// Character Symbols.
    /// </summary>
    public const string CharSymbols = "!@#$%^&*()[]";
  }
}
