using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fluky.Core.Models
{
  public enum ColorFormat
  {
    /// <summary>
    /// Hexadecimal
    /// </summary>
    Hex,

    /// <summary>
    /// Short Hexadecimal
    /// </summary>
    ShortHex,

    /// <summary>
    /// RGB color model
    /// </summary>
    Rgb,

    /// <summary>
    /// RGB color model with alpha
    /// </summary>
    Rgba,

    /// <summary>
    /// Hexadecimal with 0x prefix
    /// </summary>
    ConstantHex
  }
}
