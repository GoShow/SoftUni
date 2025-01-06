using _003.Demos;
using System.Reflection;

namespace _002.Demos;

public class Human
{
    public Human()
    {
        string executing = Assembly.GetExecutingAssembly().FullName;
        string calling = Assembly.GetCallingAssembly().FullName;
        string entry = Assembly.GetEntryAssembly().FullName;

        Person person = new();
    }
}
