using System;

namespace CustomDoublyLinkedList;

public class StartUp
{
    public static void Main()
    {
        DoublyLinkedList list = new();

        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(5);

        _ = list.RemoveLast();
        _ = list.RemoveLast();
        _ = list.RemoveFirst();
        _ = list.RemoveFirst();
        _ = list.RemoveFirst();

        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);
        list.AddFirst(4);
        list.AddFirst(5);

        int[] array = list.ToArray();

        foreach (int i in array)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("===========");

        list.ForEach(number => Console.WriteLine(number));

        ListNode node = list.Find(4);

        list.AddBefore(node, 123);

        Console.WriteLine("===========");

        list.ForEach(x => Console.WriteLine(x));
    }
}
