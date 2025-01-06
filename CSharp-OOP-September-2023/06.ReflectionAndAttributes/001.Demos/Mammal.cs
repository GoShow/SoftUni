using _002.Demos;
using System.Reflection;

namespace _001.Demos;

public class Mammal
{
    public Mammal()
    {
        string executing = Assembly.GetExecutingAssembly().FullName;
        string calling = Assembly.GetCallingAssembly().FullName;
        string entry = Assembly.GetEntryAssembly().FullName;

        Human human = new();
    }
}
