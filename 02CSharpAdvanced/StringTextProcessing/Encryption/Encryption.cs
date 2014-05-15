using System;
using System.Text;

class Encryption
{
    static string Encrypt(string message, string cypher)
    {
        int messLen = message.Length;
        int cypherLen = cypher.Length;
        StringBuilder cypheredMessage = new StringBuilder();

        if (messLen >= cypherLen)
        {
            for (int i = 0; i < messLen; i++)
            {
                int messageSymbol = (int)(message[i] - 'A');
                int cypherSymbol = (int)(cypher[i % cypherLen] - 'A');
                int newSymbol = (messageSymbol ^ cypherSymbol) + 65;

                cypheredMessage.Append((char)newSymbol);
            }
            return cypheredMessage.ToString();
        }
        else //cypherLen is greater so we need to mod the message index
        {
            cypheredMessage.Append(message);
            for (int i = 0; i < cypherLen; i++)
            {
                char current = cypheredMessage[i % messLen];
                int messageSymbol = (int)(cypheredMessage[i % messLen] - 'A');
                int cypherSymbol = (int)(cypher[i] - 'A');
                int newSymbol = (messageSymbol ^ cypherSymbol) + 65;

                cypheredMessage.Replace(current, (char)newSymbol, i % messLen, 1);
            }
            return cypheredMessage.ToString();
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter message in capital letters:");
        string message = Console.ReadLine();
        Console.WriteLine("Enter cypher in capital letters:");
        string cypher = Console.ReadLine();

        string encrypted = Encrypt(message, cypher);
        Console.WriteLine("The encrypted message is:");
        Console.WriteLine(encrypted);
    }
}