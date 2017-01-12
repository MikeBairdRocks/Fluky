using System;

namespace Fluky.Types
{
  [Flags]
  public enum GenderType : byte
  {
    Any = 0,
    Male = 1,
    Female = 2
  }
}