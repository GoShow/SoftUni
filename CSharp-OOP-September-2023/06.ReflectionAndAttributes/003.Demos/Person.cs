using System.Reflection;

namespace _003.Demos;

public class Person
{
    public Person()
    {
        string executing = Assembly.GetExecutingAssembly().FullName;
        string calling = Assembly.GetCallingAssembly().FullName;
        string entry = Assembly.GetEntryAssembly().FullName;
    }
}
