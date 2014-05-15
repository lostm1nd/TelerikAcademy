//Write a program that parses an URL address
//given in the format: [protocol]://[server]/[resource]

using System;
using System.Text;

class Program
{
    static void ParseURL(string url)
    {
        int indexColon = url.IndexOf(":");
        string protocol = url.Substring(0, indexColon);

        int indexSlashStart = url.IndexOf("//");
        int indexSlashEnd = url.IndexOf("/", indexSlashStart + 2);
        string server = url.Substring(indexSlashStart + 2, indexSlashEnd - (indexSlashStart + 2));

        string resource = url.Substring(indexSlashEnd + 1);
        Console.WriteLine("Protocol: {0}", protocol);
        Console.WriteLine("Server: {0}", server);
        Console.WriteLine("Resource: {0}", resource);

    }

    static void Main()
    {
        Console.WriteLine("Enter url in the format : [protocol]://[server]/[resource]");
        string getURL = Console.ReadLine();

        ParseURL(getURL);
    }
}