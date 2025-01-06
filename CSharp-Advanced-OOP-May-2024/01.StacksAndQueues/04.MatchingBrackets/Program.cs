using System;
using System.Collections.Generic;

string input = Console.ReadLine();
Stack<int> openingBracketsIndices = new();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        openingBracketsIndices.Push(i);
    }
    else if (input[i] == ')')
    {
        int start = openingBracketsIndices.Pop();
        int end = i;

        string subExpression = input.Substring(start, end - start + 1);

        Console.WriteLine(subExpression);
    }
}