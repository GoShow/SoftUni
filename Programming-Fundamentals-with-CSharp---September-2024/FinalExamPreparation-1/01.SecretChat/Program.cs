using System;
using System.Linq;

namespace _01.SecretChat;

internal class Program
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();

        string command = null;
        while ((command = Console.ReadLine()) != "Reveal")
        {
            string[] tokens = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];

            switch (action)
            {
                case "InsertSpace":
                    message = InsertSpace(int.Parse(tokens[1]), message);
                    break;
                case "Reverse":
                    message = Reverse(tokens[1], message);
                    break;
                case "ChangeAll":
                    message = ChangeAll(tokens[1], tokens[2], message);
                    break;
            }
        }

        Console.WriteLine($"You have a new text message: {message}");
    }

    static string InsertSpace(int index, string message)
    {
        message = message.Insert(index, " ");

        Console.WriteLine(message);

        return message;
    }

    static string Reverse(string substring, string message)
    {
        int index = message.IndexOf(substring);

        if (index != -1)
        {
            string beforeSubstring = message.Substring(0, index);

            string afterSubstring = message.Substring(index + substring.Length);

            string reversed = new string(substring.Reverse().ToArray());

            message = beforeSubstring + afterSubstring + reversed;

            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("error");
        }

        return message;
    }

    static string ChangeAll(string substring, string replacement, string message)
    {
        message = message.Replace(substring, replacement);

        Console.WriteLine(message);

        return message;
    }
}
