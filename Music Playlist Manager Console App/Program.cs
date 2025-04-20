using Music_Playlist_Manager_Console_App.Models;
using Music_Playlist_Manager_Console_App.Services;

namespace Music_Playlist_Manager_Console_App;
    internal class Program
    {
        static void Main(string[] args)
        {
            var songService = new SongService();
            var playlistService = new PlaylistService();

            var song1 = new Song(1, "Song A", new List<string> { "Artist 1" }, GenreEnum.Pop, 180);
            var song2 = new Song(2, "Song B", new List<string> { "Artist 2" }, GenreEnum.Rock, 210);
            var song3 = new Song(3, "Song C", new List<string> { "Artist 1" }, GenreEnum.Jazz, 200);

            songService.Create(song1);
            songService.Create(song2);
            songService.Create(song3);

            var playlist = new Playlist(1, "My Playlist");
            playlist.AddSong(song1);
            playlist.AddSong(song2);
            playlistService.Create(playlist);

            playlist.PlaylistName = "Updated Playlist";
            playlistService.Update(playlist);

            var filteredSongs = playlistService.FilterSongs(1, artistName: "Artist 1");
            Console.WriteLine("Filtered Songs:");
            foreach (var song in filteredSongs)
            {
                Console.WriteLine(song.SongName);
            }

            songService.Delete(2);

            playlistService.Delete(1);
        }

    }

