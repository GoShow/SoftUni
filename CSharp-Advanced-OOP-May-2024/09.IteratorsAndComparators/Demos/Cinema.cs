using System.Collections;
using System.Collections.Generic;
//IEnumerator cinemaEnumerator = cinema.GetEnumerator();

//while (cinemaEnumerator.MoveNext())
//{
//    Console.WriteLine(cinemaEnumerator.Current);
//}

public class Cinema : IEnumerable<int>
{
    private List<int> seats { get; set; }

    public Cinema(List<int> seats)
    {
        this.seats = seats;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new CinemaEnumerator(seats);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}






