using System;

namespace SoftUniKindergarten;

public class StartUp
{
    static void Main(string[] args)
    {
        var aaa = "asd";


        Do(aaa);

        Console.WriteLine(aaa);
        void Do(string bbb)
        {
            bbb += "v";
            Console.WriteLine();
        }
    }
}