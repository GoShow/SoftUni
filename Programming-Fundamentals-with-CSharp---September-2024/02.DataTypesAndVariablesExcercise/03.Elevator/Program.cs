using System;

namespace _03.Elevator;

internal class Program
{
    static void Main(string[] args)
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        int capacity = int.Parse(Console.ReadLine());

        int courses = numberOfPeople / capacity;
        int peopleLeft = numberOfPeople % capacity;

        if (numberOfPeople < capacity)
        {
            Console.WriteLine(1);
        }
        else
        {
            if (peopleLeft > 0)
            {
                courses++;
            }

            Console.WriteLine(courses);
        }
    }
}
