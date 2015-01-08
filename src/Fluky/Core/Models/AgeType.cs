using System;

namespace Fluky.Core.Models
{
  /// <summary>
  /// 
  /// </summary>
  [Flags]
  public enum AgeType : byte
  {
    /// <summary>
    /// 
    /// </summary>
    Any = 0,
    
    /// <summary>
    /// 
    /// </summary>
    Child = 1,

    /// <summary>
    /// 
    /// </summary>
    Teen = 2,

    /// <summary>
    /// 
    /// </summary>
    Adult = 3,

    /// <summary>
    /// 
    /// </summary>
    Senior = 4
  }
}