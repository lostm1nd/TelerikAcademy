using System;

class DaysBetweenTwoDates
{
    static void Main()
    {
        Console.WriteLine("Enter two date with this format: day.month.year");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        TimeSpan dateDifference = secondDate - firstDate;
        int daysBetweenDates = dateDifference.Days;
        if (daysBetweenDates < 0)
        {
            daysBetweenDates = daysBetweenDates * -1;
        }

        Console.WriteLine("Days between the dates: {0}", daysBetweenDates);
    }
}
