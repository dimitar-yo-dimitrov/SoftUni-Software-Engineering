using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
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
            int numSong = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numSong; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

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
            else if (typeList == "favourite")
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
            else
            {
                List<Song> filteredSong = songs
                    .Where(s => s.TypeList == typeList)
                    .ToList();

                foreach (Song song in filteredSong)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
