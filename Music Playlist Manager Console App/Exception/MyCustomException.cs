using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Playlist_Manager_Console_App.Exception;

public class PlaylistAlreadyExistsException 
{
    public string Message { get; set; } = "Playlist already exists.";
    public PlaylistAlreadyExistsException(string message)
    {
        Message = message;
    }
}

