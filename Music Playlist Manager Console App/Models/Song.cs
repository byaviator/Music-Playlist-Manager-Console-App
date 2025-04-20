using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Playlist_Manager_Console_App.Models;

public class Song
{
    public int Id { get; set; }
    public string SongName { get; set; }
    public List<string> ArtistNames { get; set; }
    public GenreEnum Genre { get; set; }
    public int Duration { get; set; } 

    public Song(int id, string songName, List<string> artistNames, GenreEnum genre, int duration)
    {
        Id = id;
        SongName = songName;
        ArtistNames = artistNames;
        Genre = genre;
        Duration = duration;
    }

}
