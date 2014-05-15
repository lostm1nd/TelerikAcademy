using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractEmail
{
    static void Main()
    {
        string text = "This is my email:jamie44@hotmail.com!\nHello send me a letter at gizmo.work@gmail.com;\n" +
                      "Add me-p_er23@doom.eu\nMy new place str4ng3R_22@oblivion.ca. Working on blast_over.me@newuniverse.info";
        Console.WriteLine(text);

        string pattern = @"[a-zA-Z0-9._]+@\w+\.\w{2,5}";
        Match emailMatch = Regex.Match(text, pattern);

        Console.WriteLine("----Extracted emails-----");
        if (emailMatch.Success)
        {
            while (emailMatch.Success)
            {
                Console.WriteLine("Email found: {0}", emailMatch.Value);
                emailMatch = emailMatch.NextMatch();
            }
        }
        else
        {
            Console.WriteLine("No email were found.");
        }
    }
}
