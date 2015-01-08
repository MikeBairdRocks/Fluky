using System;

namespace Fluky.Core.Models
{
  [Flags]
  public enum HonorificType : byte
  {
    Any = 0,
    Common = 1,
    Formal = 2,
    Professor = 3,
    Religious = 4
  }
}