using System;
using System.Collections;
using System.Collections.Generic;

Cinema cinema = new(new List<int> { 1, 2, 3, 4, 5 });

foreach (int seat in cinema)
{
    Console.WriteLine(seat);
}

IEnumerator cinemaEnumerator = cinema.GetEnumerator();

while (cinemaEnumerator.MoveNext())
{
    Console.WriteLine(cinemaEnumerator.Current);
}







