using System;

namespace CustomDoublyLinkedList;

public class DoublyLinkedList
{
    private ListNode head;
    private ListNode tail;

    public int Count { get; private set; }

    public void AddFirst(int value)
    {
        ListNode newHead = new(value);

        if (head == null)
        {
            head = newHead;
            tail = newHead;

            Count++;

            return;
        }

        head.Previous = newHead;
        newHead.Next = head;
        head = newHead;

        Count++;
    }

    public void AddLast(int value)
    {
        ListNode newTail = new(value);

        if (tail == null)
        {
            head = newTail;
            tail = newTail;

            Count++;

            return;
        }

        tail.Next = newTail;
        newTail.Previous = tail;
        tail = newTail;

        Count++;
    }

    public int RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        int removedValue = head.Value;

        head = head.Next;

        if (head != null)
        {
            head.Previous = null;
        }
        else
        {
            tail = null;
        }

        Count--;

        return removedValue;
    }

    public int RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        int removedValue = tail.Value;

        tail = tail.Previous;

        if (tail != null)
        {
            tail.Next = null;
        }
        else
        {
            head = null;
        }

        Count--;

        return removedValue;
    }

    public void ForEach(Action<int> action)
    {
        ListNode node = head;

        while (node != null)
        {
            action(node.Value);
            node = node.Next;
        }
    }

    public int[] ToArray()
    {
        int[] array = new int[Count];

        ListNode node = head;
        int counter = 0;

        while (node != null)
        {
            array[counter] = node.Value;
            node = node.Next;
            counter++;
        }

        return array;
    }

    public ListNode Find(int value)
    {
        ListNode node = head;

        while (node != null)
        {
            if (node.Value == value)
            {
                return node;
            }

            node = node.Next;
        }

        return null;
    }

    public void AddBefore(ListNode currentNode, int value)
    {
        if (currentNode == null)
        {
            throw new InvalidOperationException("Cannot insert before unexisting node");
        }

        ListNode newNode = new(value);
        ListNode prevoiusNode = currentNode.Previous;

        newNode.Previous = prevoiusNode;
        newNode.Next = currentNode;

        prevoiusNode.Next = newNode;
        currentNode.Previous = newNode;
    }
}
