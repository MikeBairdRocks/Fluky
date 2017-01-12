using System;

namespace Fluky.Types
{
  [Flags]
  public enum HonorificType
  {
    Any = 0,
    Common = 1,
    Formal = 2,
    Professor = 3,
    Religious = 4
  }
}