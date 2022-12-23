using System.Linq;
using System.Text;

namespace MusicHub
{
    using System;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            // Test your solutions here

            // 02.All Albums Produced by Given Producer
            // string result = ExportAlbumsInfo(context, producerId: 9);

            // 03.Songs Above Given Duration
            string result = ExportSongsAboveDuration(context, duration: 4);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Producers
                .First(p => p.Id == producerId)
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.Date.ToString(format: "MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(w => w.SongWriter)
                        .ToList(),
                    AlbumPrice = a.Price,
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            foreach (var album in albums)
            {
                int count = 1;

                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{count++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice:f2}")
                        .AppendLine($"---Writer: {song.SongWriter}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .ToList()
                .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                .OrderBy(s => s.SongName)
                .ThenBy(w => w.WriterName)
                .ThenBy(p => p.PerformerFullName)
                .ToList();

            int count = 1;

            foreach (var song in songs)
            {

                sb.AppendLine($"-Song #{count++}")
                  .AppendLine($"---SongName: {song.SongName}")
                  .AppendLine($"---Writer: {song.WriterName}")
                  .AppendLine($"---Performer: {song.PerformerFullName}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                  .AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

