using System;
using System.Collections.Generic;

namespace IteratorsAndComparators;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        Title = title;
        Year = year;
        Authors = new List<string>(authors);
    }

    public string Title { get; set; }
    public int Year { get; set; }
    List<string> Authors { get; set; }

    public int CompareTo(Book other)
    {
        int result = this.Year.CompareTo(other.Year);

        if (result == 0)
        {
            result = this.Title.CompareTo(other.Title);
        }

        return result;
    }
    public override string ToString() => $"{Title} - {Year}";
}
