using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Playlist_Manager_Console_App.Models;
    public class Playlist
    {
        public int Id { get; set; }
        public string PlaylistName { get; set; }
        public List<Song> Songs { get; set; }

        public Playlist(int id, string playlistName)
        {
            Id = id;
            PlaylistName = playlistName;
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }
    }
