using System;
//IEnumerator enumerator = GetNumbers();
//enumerator.MoveNext();
//enumerator.MoveNext();
//enumerator.MoveNext();
//enumerator.MoveNext();

//static IEnumerator<int> GetNumbers()
//{
//    Console.WriteLine("Before 1");

//    yield return 1;
//    Console.WriteLine("After 1");
//    Console.WriteLine("Before 2");

//    yield return 2;

//    Console.WriteLine("After 2");
//    Console.WriteLine("Before 3");

//    yield return 3;

//    Console.WriteLine("After 3");
//}


public class Person : IComparable<Person>
{
    public int Age { get; set; }

    public string Name { get; set; }

    public int CompareTo(Person other)
    {
        int result = Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = Age.CompareTo(other.Age);
        }

        return result;
    }
}






