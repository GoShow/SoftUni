using System;
using System.Collections.Generic;

HashSet<string> vipGuests = new();
HashSet<string> regularGuests = new();

string input;
while ((input = Console.ReadLine()) != "PARTY")
{
    if (char.IsDigit(input[0]))
    {
        vipGuests.Add(input);
    }
    else
    {
        regularGuests.Add(input);
    }
}

while ((input = Console.ReadLine()) != "END")
{
    if (char.IsDigit(input[0]))
    {
        vipGuests.Remove(input);
    }
    else
    {
        regularGuests.Remove(input);
    }
}

Console.WriteLine(vipGuests.Count + regularGuests.Count);

foreach (var guest in vipGuests)
{
    Console.WriteLine(guest);
}
foreach (var guest in regularGuests)
{
    Console.WriteLine(guest);
}
