using System;
using System.Text;

class ReplaceHTMLTags
{
    static void Main()
    {
        string htmlText = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course." +
                          @"Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

        Console.WriteLine(htmlText);

        StringBuilder replacingTags = new StringBuilder(htmlText);
        replacingTags.Replace("</a>", "[/URL]");
        replacingTags.Replace("<a href=", "[URL=");
        replacingTags.Replace("\">", "\"]");
        Console.WriteLine("----Tags replaced-----");
        Console.WriteLine(replacingTags.ToString());
    }
}
