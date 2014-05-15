using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

class ExtractDates
{
    static void Main()
    {
        string text = "The day 19.05.1957 was a great day. The next year everybody\ncelebrated 19.05.1958. Fifteen years after\n19.05.1972 was still celabrated.";
        Console.WriteLine(text);
        CultureInfo canadaCultureInfo = new CultureInfo("en-CA");
        Match datesMatch = Regex.Match(text, "[0-9]{2}.[0-9]{2}.[0-9]{4}");

        if (datesMatch.Success)
        {
            while (datesMatch.Success)
            {
                DateTime parsedDate = DateTime.Parse(datesMatch.Value);
                Console.WriteLine("The date printed with canadian culture info: {0}", parsedDate.ToString("d", canadaCultureInfo));
                datesMatch = datesMatch.NextMatch();
            }
        }
        else
        {
            Console.WriteLine("There are no dates matching the patter DD.MM.YYYY");
        }
    }
}
