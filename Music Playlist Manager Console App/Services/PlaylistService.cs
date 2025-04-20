using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Playlist_Manager_Console_App.Models;

namespace Music_Playlist_Manager_Console_App.Services;

public class PlaylistService
{
    private List<Playlist> _playlists;

    public PlaylistService()
    {
        _playlists = new List<Playlist>();
    }

    public void Create(Playlist playlist)
    {
        if (_playlists.Any(p => p.Id == playlist.Id))
        {
            throw new InvalidOperationException("Playlist with the same ID already exists.");
        }
        _playlists.Add(playlist);
    }

    public Playlist Read(int id)
    {
        return _playlists.FirstOrDefault(p => p.Id == id) ?? throw new KeyNotFoundException("Playlist not found.");
    }

    public void Update(Playlist playlist)
    {
        var existingPlaylist = Read(playlist.Id);
        existingPlaylist.PlaylistName = playlist.PlaylistName;
    }

    public void Delete(int id)
    {
        var playlist = Read(id);
        _playlists.Remove(playlist);
    }

    public List<Song> FilterSongs(int playlistId, string artistName = null, string songName = null, GenreEnum? genre = null)
    {
        var playlist = Read(playlistId);
        var filteredSongs = playlist.Songs.AsEnumerable();

        if (!string.IsNullOrEmpty(artistName))
        {
            filteredSongs = filteredSongs.Where(s => s.ArtistNames.Contains(artistName, StringComparer.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(songName))
        {
            filteredSongs = filteredSongs.Where(s => s.SongName.ToLower().Contains(songName.ToLower()));
        }

        if (genre.HasValue)
        {
            filteredSongs = filteredSongs.Where(s => s.Genre == genre);
        }

        return filteredSongs.ToList();
    }
}
