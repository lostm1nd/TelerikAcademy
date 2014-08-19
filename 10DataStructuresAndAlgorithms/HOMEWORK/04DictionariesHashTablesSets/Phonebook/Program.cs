namespace Phonebook
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            HashPhonebook phonebook = new HashPhonebook();

            using (StreamReader reader = new StreamReader("phones.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] tokens = line.ToLower().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] names = tokens[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string town = tokens[1].Trim();
                    string phone = tokens[2].Trim();

                    foreach (var name in names)
                    {
                        phonebook.AddEntry(name, phone);
                        phonebook.AddEntry(name, town, phone);
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader("commands.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (line.StartsWith("find("))
                    {
                        string[] tokens = line.ToLower().Split(new char[] { '(', ',', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens.Length == 2)
                        {
                            Console.WriteLine("Entry for " + tokens[1] + ": " + string.Join("; ", phonebook.Find(tokens[1])));
                        }
                        else
                        {
                            phonebook.Find(tokens[1], tokens[2]);
                            Console.WriteLine("Entry for " + tokens[1] + " from " + tokens[2] + ": " + string.Join("; ", phonebook.Find(tokens[1])));
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}