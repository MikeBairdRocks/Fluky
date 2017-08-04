using System;
using Fluky.Extensions;
using Fluky.Types;

namespace Fluky
{
  public partial class Randomizer
  {
    public float DistributionNormal(float mean, float standardDeviation)
    {
      // Get random normal from Standard Normal Distribution
      var randomNormalNumber = DistributionStandardNormal();

      // Stretch distribution to the requested sigma variance
      randomNormalNumber *= standardDeviation;

      // Shift mean to requested mean:
      randomNormalNumber += mean;

      // now you have a number selected from a normal distribution with requested mean and sigma!
      return randomNormalNumber;

    }

    public float DistributionStandardNormal()
    {
      // This code follows the polar form of the muller transform:
      // https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform#Polar_form
      // also known as Marsaglia polar method 
      // https://en.wikipedia.org/wiki/Marsaglia_polar_method

      // calculate points on a circle
      float u, v;

      float s; // this is the hypotenuse squared.
      do
      {
        u = Float(-1, 1);
        v = Float(-1, 1);
        s = (u * u) + (v * v);
      } while (!(Math.Abs(s) > 0.001f && s < 1)); // keep going until s is nonzero and less than one

      // TODO: allow a user to specify how many random numbers they want!
      // choose between u and v for seed (z0 vs z1)
      var seed = Integer(0, 2) == 0 ? u : v;

      // create normally distributed number.
      var z = (seed * Math.Sqrt(-2.0f * Math.Log(s) / s));
      var result = z.ToFloat();

      return result;
    }

    //--------------------------------------------------------------------------------------------
    // Sloped Distribution
    //--------------------------------------------------------------------------------------------

    public float DistributionRangeSlope(float min, float max, float skew, DistributionDirection direction)
    {
      return min + DistributionSloped(skew, direction) * (max - min);
    }

    public float DistributionSloped(float skew, DistributionDirection direction)
    {
      // the difference in scale is just the same as the max y-value..
      var maxY = skew;

      // our curve will go from 0 to max_x.
      var maxX = Inverse_Sec_Sqrd(maxY);

      var maxCdf = Sec_Sqrd_CumulativeDistributionFunction(maxX);

      var u = Float(0, maxCdf);
      var xVal = Sec_Sqrd_InverseCumulativeDistributionFunction(u);

      // scale to [0,1]
      var value = xVal / maxX;

      if (direction == DistributionDirection.Left)
        value = 1.0f - value;

      return value;
    }

    //--------------------------------------------------------------------------------------------
    // Linear Distribution
    //--------------------------------------------------------------------------------------------

    // Returns random in range [min, max] with linear distribution of given slope.
    public float DistributionRangeLinear(float min, float max, float slope)
    {
      var val = DistributionRandomLinear(slope);

      return min + (max - min) * val;
    }

    // Returns random in range [0,1] with linear distribution of given slope.
    public float DistributionRandomLinear(float slope)
    {
      var absValue = DistributionLinearWithPositiveSlope(Math.Abs(slope));
      if (slope < 0)
        return 1 - absValue;

      return absValue;
    }

    private float DistributionLinearWithPositiveSlope(float slope)
    {
      if (Math.Abs(slope) < 0.001f)
        return Float(0.0f, 1.0f);

      float x, y;
      do
      {
        x = Float(0.0f, 1.0f);
        y = Float(0.0f, 1.0f);
        if (slope < 1)
        {
          y -= (1 - slope) / 2.0f;
        }
      } while (y > x * slope);

      return x;
    }

    //--------------------------------------------------------------------------------------------
    // Exponential Distribution
    //--------------------------------------------------------------------------------------------

    public float DistributionExponentialRange(float min, float max, float exponent, DistributionDirection direction)
    {
      return min + DistributionExponential(exponent, direction) * (max - min);
    }

    public float DistributionExponential(float exponent, DistributionDirection direction)
    {
      // our curve will go from 0 to 1.
      var maxCdf = ExponentialRightCdf(1.0f, exponent);

      var u = Float(0.0f, maxCdf);
      var xVal = EponentialRightInverseCdf(u, exponent);

      if (direction == DistributionDirection.Left)
        xVal = 1.0f - xVal;

      return xVal;
    }




    // The inverse of the curve.
    private float DistributionExponentialRightInverse(float y, float exponent)
    {
      return Math.Pow(y, 1.0f / exponent).ToFloat();
    }

    // The integral of the exponent curve.
    private static float ExponentialRightCdf(float x, float exponent)
    {
      var integralExp = exponent + 1.0f;
      var exponentialRightCdf = (Math.Pow(x, integralExp)) / integralExp;
      return exponentialRightCdf.ToFloat();
    }

    // The inverse of the integral of the exponent curve.
    private static float EponentialRightInverseCdf(float x, float exponent)
    {
      var integralExp = exponent + 1.0f;
      return Math.Pow(integralExp * x, 1.0f / integralExp).ToFloat();
    }

    /// <summary>
    /// The inverse of the sec^2 function.
    /// </summary>
    /// <param name="y">The y coordinate. if y less than 1, returns NaN. </param>
    private float Inverse_Sec_Sqrd(float y)
    {
      // Note: arcsec(x) = arccos(1/x)

      // return arcsec(sqrt(y))
      var inverseSecSqrd = Math.Acos(1.0f / Math.Sqrt(y));
      return inverseSecSqrd.ToFloat();
    }

    /// <summary>
    /// The integral of sec^2
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private static float Sec_Sqrd_CumulativeDistributionFunction(float x)
    {
      // The cumulative distribution function for sec^2 is just the definite integral of sec^2(x) = tan(x) - tan(0) = tan(x)
      return Math.Tan(x).ToFloat();
    }

    /// <summary>
    /// The inverse of the integral of sec^2
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private static float Sec_Sqrd_InverseCumulativeDistributionFunction(float x)
    {
      // The cumulative distribution function for sec^2 is just the definite integral of sec^2(x) = tan(x) - tan(0) = tan(x)
      // Then the Inverse cumulative distribution function is just atan(x)
      return Math.Atan(x).ToFloat();
    }
  }
}
