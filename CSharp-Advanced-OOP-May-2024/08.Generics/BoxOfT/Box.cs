namespace BoxOfT;

public class Box<T>
{
    private Stack<T> elements;

    public Box()
    {
        elements = new Stack<T>();
    }

    public int Count { get { return elements.Count; } }

    public void Add(T element)
    {
        elements.Push(element);
    }

    public T Remove()
    {
        T removedElement = elements.Pop();

        return removedElement;
    }
}

