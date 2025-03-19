using System;

namespace _01.TheImitationGame;

internal class Program
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();
        string command;

        while ((command = Console.ReadLine()) != "Decode")
        {
            string[] tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];

            switch (action)
            {
                case "Move":
                    int count = int.Parse(tokens[1]);

                    string substring = message.Substring(0, count);
                    message = message.Remove(0, count);
                    message += substring;

                    break;
                case "Insert":
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];

                    message = message.Insert(index, value);

                    break;
                case "ChangeAll":
                    string substringToReplace = tokens[1];
                    string replacement = tokens[2];

                    message = message.Replace(substringToReplace, replacement);
                    break;
            }
        }

        Console.WriteLine($"The decrypted message is: {message}");
    }
}
