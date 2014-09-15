namespace GetDayService
{
    using System;
    using System.Globalization;

    public class DayTeller : IDayTeller
    {
        public string GetDayFromDate(DateTime date)
        {
            //CultureInfo bulgarian = new CultureInfo("bg-BG");
            CultureInfo uk = new CultureInfo("en-GB");
            string day = uk.DateTimeFormat.GetDayName(date.DayOfWeek);

            return day;
        }
    }
}