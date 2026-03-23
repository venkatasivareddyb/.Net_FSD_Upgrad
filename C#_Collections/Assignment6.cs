using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collections
{
    class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }

    class Assignment6
    {
        static void Main()
        {
            LinkedList<Song> playlist = new LinkedList<Song>();
            var s1 = new Song { Id = 1, Title = "Song A", Artist = "Artist1" };
            var s2 = new Song { Id = 2, Title = "Song B", Artist = "Artist2" };
            var s3 = new Song { Id = 3, Title = "Song C", Artist = "Artist3" };

            playlist.AddFirst(s1);
            playlist.AddLast(s2);
            playlist.AddAfter(playlist.First, s3);

            foreach (var s in playlist) Console.WriteLine($"{s.Title}");

            var node = playlist.Find(s2);
            playlist.Remove(node);

            Console.WriteLine("\nForward:");
            foreach (var s in playlist) Console.WriteLine(s.Title);

            Console.WriteLine("\nBackward:");
            var current = playlist.Last;
            while (current != null)
            {
                Console.WriteLine(current.Value.Title);
                current = current.Previous;
            }

            var found = playlist.Find(new Song { Title = "Song A" });
            Console.WriteLine("\nPlay Next: " + playlist.First.Next.Value.Title);
        }
    }
}
