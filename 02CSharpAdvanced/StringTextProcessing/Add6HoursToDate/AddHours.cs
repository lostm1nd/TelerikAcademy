using System;

class AddHours
{
    static void Main()
    {
        Console.WriteLine("Enter date and time with this format: day.month.year hour:minute:second");
        string dateAndTime = Console.ReadLine();

        DateTime parsedDate = DateTime.Parse(dateAndTime);
        parsedDate = parsedDate.AddHours(6).AddMinutes(30);

        Console.WriteLine("It is the {0} of {1} {2}. The time is {3}", parsedDate.Day, parsedDate.ToString("MMMM"), 
                           parsedDate.Year, parsedDate.TimeOfDay);
    }
}