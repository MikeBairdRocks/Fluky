using System;
using System.Collections.Generic;
using Fluky.Core.Models;

namespace Fluky.Framework
{
  public partial class Randomizer
  {
    //public string AmPm()
    //{
    //  throw new NotImplementedException();
    //}

    // Hammertime
    //public string UnixTime()
    //{
    //  throw new NotImplementedException();
    //}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="twentyfour"></param>
    /// <returns></returns>
    public int Hour(bool twentyfour = false)
    {
      var max = twentyfour ? 24 : 12;
      return Natural(1, max);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int Minute()
    {
      return Natural(max: 59);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int Second()
    {
      return Natural(max: 59);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int Millisecond()
    {
      return Natural(max: 999);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int Timestamp()
    {
      var max = (int)(DateTime.Now.TimeOfDay.TotalMinutes / 1000);
      return Natural(1, max);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="minYear"></param>
    /// <returns></returns>
    public DateTime Date(int? minYear = null)
    {
      minYear = minYear.HasValue ? minYear.Value : 1900;
      var year = Year(minYear.Value);
      var month = Month();
      var day = Natural(1, DateTime.DaysInMonth(year, month.Numeric));
      var hour = Hour();
      var minute = Minute();
      var second = Second();
      var millisecond = Millisecond();

      var date = new DateTime(year, month.Numeric, day, hour, minute, second, millisecond);

      return date;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="american"></param>
    /// <returns></returns>
    public string Date(bool american)
    {
      string dateString;
      var date = Date();
      if (american)
      {
        dateString = string.Format("{0}/{1}/{2}", date.Month, date.Day, date.Year);
      }
      else
      {
        dateString = string.Format("{0}/{1}/{2}", date.Day, date.Month, date.Year);
      }

      return dateString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Month Month()
    {
      var month = Pick(Months());
      return month;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string MonthName()
    {
      var month = Pick(Months());
      return month.Name;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public int Year(int min, int? max = null)
    {
      max = max.HasValue ? max.Value : DateTime.Now.Year;

      return Natural(min, max.Value);
    }

    private List<Month> Months()
    {
      return new List<Month>
      {
        new Month("January", "Jan", 1),
        new Month("February", "Feb", 2),
        new Month("March", "Mar", 3),
        new Month("April", "Apr", 4),
        new Month("May", "May", 5),
        new Month("June", "Jun", 6),
        new Month("July", "Jul", 7),
        new Month("August", "Aug", 8),
        new Month("September", "Sep", 9),
        new Month("October", "Oct", 10),
        new Month("November", "Nov", 11),
        new Month("December", "Dec", 12)
      };
    }
  }
}
