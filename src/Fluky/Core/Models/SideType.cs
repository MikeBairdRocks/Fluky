using System;

namespace Fluky.Core.Models
{
  [Flags]
  public enum SideType : byte
  {
    Any = 0,
    East = 1,
    West = 2
  }
}
