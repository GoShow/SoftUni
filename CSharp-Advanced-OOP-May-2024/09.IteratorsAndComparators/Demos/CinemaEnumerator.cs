using System.Collections;
using System.Collections.Generic;

public class CinemaEnumerator : IEnumerator<int>
{
    int index = -1;
    private List<int> seats { get; set; }

    public CinemaEnumerator(List<int> seats)
    {
        this.seats = seats;
    }

    public int Current =>
        seats[index];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        index++;

        return index < seats.Count;
    }

    public void Reset()
    {
        index = -1;
    }

    public void Dispose()
    {

    }
}






