using System;
using System.Collections.Generic;

namespace _03.Songs;

internal class Program
{
    static void Main(string[] args)
    {
        List<Song> songs = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] songProperties = Console.ReadLine().Split('_');

            Song song = new(songProperties[0], songProperties[1], songProperties[2]);

            songs.Add(song);
        }

        string typeList = Console.ReadLine();

        if (typeList == "all")
        {
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Name);
            }
        }
        else
        {
            foreach (Song song in songs)
            {
                if (song.TypeList == typeList)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}

class Song
{
    public Song(string typeList, string name, string time)
    {
        TypeList = typeList;
        Name = name;
        Time = time;
    }

    public string TypeList { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }
}