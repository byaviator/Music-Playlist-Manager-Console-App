using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Playlist_Manager_Console_App.Models;

namespace Music_Playlist_Manager_Console_App.Services;

public class SongService
{
    private List<Song> _songs;

    public SongService()
    {
        _songs = new List<Song>();
    }

    public void Create(Song song)
    {
        if (_songs.Any(s => s.Id == song.Id))
        {
            throw new InvalidOperationException("Song with the same ID already exists.");
        }
        _songs.Add(song);
    }

    public Song Read(int id)
    {
        return _songs.FirstOrDefault(s => s.Id == id) ?? throw new KeyNotFoundException("Song not found.");
    }

    public void Update(Song song)
    {
        var existingSong = Read(song.Id);
        existingSong.SongName = song.SongName;
        existingSong.ArtistNames = song.ArtistNames;
        existingSong.Genre = song.Genre;
        existingSong.Duration = song.Duration;
    }

    public void Delete(int id)
    {
        var song = Read(id);
        _songs.Remove(song);
    }
}
