using System;

namespace Fluky.Core.Models
{
  /// <summary>
  /// 
  /// </summary>
  [Flags]
  public enum CasingType : byte
  {
    /// <summary>
    /// 
    /// </summary>
    Both = 0,

    /// <summary>
    /// 
    /// </summary>
    Lower = 1,

    /// <summary>
    /// 
    /// </summary>
    Upper = 2
  }
}