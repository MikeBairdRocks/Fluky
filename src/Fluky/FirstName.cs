﻿using Fluky.Types;

namespace Fluky
{
  public class FirstName
  {
    public FirstName()
    {
    }

    public FirstName(string name, GenderType genderType)
    {
      Name = name;
      GenderType = genderType;
    }

    public string Name { get; set; }
    public GenderType GenderType { get; set; }
  }
}
