using System.Collections.Generic;

public class PersonComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Age.CompareTo(y.Age);

        if (result == 0)
        {
            result = x.Name.CompareTo(y.Name);
        }

        return result;
    }
}






