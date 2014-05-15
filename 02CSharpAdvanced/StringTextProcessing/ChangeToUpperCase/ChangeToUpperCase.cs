//You are given a text. Write a program that changes the text
//in all regions surrounded by the tags <upcase> and </upcase> to uppercase.
//The tags cannot be nested.

using System;
using System.Text;

class ChangeToUpperCase
{
    static void ToUpperCase(string text)
    {
        StringBuilder sb = new StringBuilder(text);
        int tagStart = text.IndexOf("<upcase>");
        int tagEnd = text.IndexOf("</upcase>");
        int tagStartLen = "<upcase>".Length;
        int tagEndLen = "</upcase>".Length;

        if (tagStart == -1 || tagEnd == -1)
        {
            Console.WriteLine("No tags used or invalid syntax.");
            return;
        }
        else
        {
            while (tagStart != -1 && tagEnd != -1)
            {
                //<upcase> is 8 chars so we add its length tagStart to take the first char after the tag
                //similarly we have the index where </upcase> begins so we can find the length of the string 
                //between both tags when we substract the index where the substring starts(tagStart + tagStartLen)
                //from the index we the substring ends => substring between tags = tagEnd - (tagStart + tagStartLen)
                string substring = text.Substring(tagStart + tagStartLen, tagEnd - tagStart - tagStartLen);
                sb.Remove(tagStart + tagStartLen, tagEnd - tagStart - tagStartLen);
                sb.Insert(tagStart + tagStartLen, substring.ToUpper());

                tagStart = text.IndexOf("<upcase>", tagStart + 1);
                tagEnd = text.IndexOf("</upcase>", tagEnd + 1);
            }            
        }
        sb.Replace("<upcase>", string.Empty);
        sb.Replace("</upcase>", string.Empty);
        Console.WriteLine(sb.ToString());
    }

    static void Main()
    {
        Console.WriteLine("Enter some text. Use <upcase>text</upcase> tags\nto select words you want in uppercase.");
        //string text = Console.ReadLine();
        
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        ToUpperCase(text);
    }
}
