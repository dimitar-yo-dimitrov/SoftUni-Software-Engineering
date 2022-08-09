using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SongsWith_LINQ
{
    class Program
    {
        class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numSongs; i++)
            {
                string[] date = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);

                string type = date[0];
                string name = date[1];
                string time = date[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            List<Song> filteredSongs = songs
                .Where(s => s.TypeList == typeList)
                .ToList();

            foreach (Song song in filteredSongs)
            {
                Console.WriteLine(song.Name);
            }

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
