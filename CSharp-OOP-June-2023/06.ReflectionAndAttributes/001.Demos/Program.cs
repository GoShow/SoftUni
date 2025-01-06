using System;
using System.Reflection;

Type type = typeof(Person);

PropertyInfo propertyInfo = type.GetProperty("Age");
MethodInfo methodInfo = type.GetMethod("GetName");
FieldInfo fieldInfo = type.GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);
MemberInfo[] membersInfos = type.GetMember("GetName");// check how to invoke

Person instance = Activator.CreateInstance(type, new object[] { "Ivan", 18 }) as Person;
//Person instance = Activator.CreateInstance(type, "Ivan", 18) as Person;

Console.WriteLine(instance.GetName());

fieldInfo.SetValue(instance, "Andrey");

Console.WriteLine(instance.GetName());

object result = methodInfo.Invoke(instance, null);

Console.WriteLine(result);

public class Person
{
    private string name;

    public Person(string name, int age)
    {
        this.name = name;
        Age = age;
    }

    public int Age { get; set; }

    public string GetName() => name;
}