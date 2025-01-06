using System;
using System.Collections.Generic;

List<Person> people = ReadPeople();

string condition = Console.ReadLine();
int ageTreshold = int.Parse(Console.ReadLine());

Func<Person, bool> filter = CreateFilter(condition, ageTreshold);

string format = Console.ReadLine();

Action<Person> printer = CreatePrinter(format);
PrintFilteredPeople(people, filter, printer);

static List<Person> ReadPeople()
{
    List<Person> people = new();

    int count = int.Parse(Console.ReadLine());

    for (int i = 0; i < count; i++)
    {
        string[] personTokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

        Person person = new Person();

        person.Name = personTokens[0];
        person.Age = int.Parse(personTokens[1]);

        people.Add(person);
    }

    return people;
}

static Func<Person, bool> CreateFilter(string condition, int ageTreshold)
{
    switch (condition)
    {
        case "younger": return p => p.Age < ageTreshold;
        case "older": return p => p.Age >= ageTreshold;
        default: throw new ArgumentException(condition);
    }

}

static Action<Person> CreatePrinter(string format)
{
    switch (format)
    {
        case "name age": return p => Console.WriteLine($"{p.Name} - {p.Age}");
        case "name": return p => Console.WriteLine($"{p.Name}");
        case "age": return p => Console.WriteLine($"{p.Age}");
        default: throw new ArgumentException(format);
    }
}

static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
{
    foreach (Person person in people)
    {
        if (filter(person))
        {
            printer(person);
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}