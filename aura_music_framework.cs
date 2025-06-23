// Architectural Framework for Aura Music Application

using System;
using System.Collections.Generic;

namespace AuraMusicApp
{
    // -------------------- TRACK CLASS --------------------
    public class Track
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; } // duration in seconds

        public string GetInfo()
        {
            return $"{Title} by {Artist}, Duration: {Duration}s";
        }
    }

    // -------------------- USER LOGIN --------------------
    public class UserLogin
    {
        private string userName;
        private string password;
        private bool loggedIn = false;

        public bool Login(string userName, string password)
        {
            // Simulate user authentication
            this.userName = userName;
            this.password = password;
            loggedIn = true; // assume valid for this mockup
            return loggedIn;
        }

        public void Logout()
        {
            loggedIn = false;
        }

        public bool IsLoggedIn()
        {
            return loggedIn;
        }
    }

    // -------------------- ACCOUNT CREATION --------------------
    public class AccountCreation
    {
        private string userName;
        private string password;
        private string email;

        public bool CreateAccount(string userName, string password, string email)
        {
            // Save to database in real application
            this.userName = userName;
            this.password = password;
            this.email = email;
            return true;
        }
    }

    // -------------------- SEARCH MUSIC --------------------
    public class SearchMusic
    {
        public string SearchQuery { get; set; }
        public List<Track> SearchResults { get; set; } = new();

        public List<Track> SearchByTitle(string title)
        {
            return SearchResults.FindAll(t => t.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<Track> SearchByArtist(string artist)
        {
            return SearchResults.FindAll(t => t.Artist.Contains(artist, StringComparison.OrdinalIgnoreCase));
        }

        public List<Track> SearchByGenre(string genre)
        {
            // Stub - Track class has no genre field yet
            return new List<Track>();
        }

        public void ClearSearch()
        {
            SearchQuery = string.Empty;
            SearchResults.Clear();
        }
    }

    // -------------------- PLAYLIST CREATION --------------------
    public class PlaylistCreation
    {
        public string Name { get; set; }
        public List<Track> Tracks { get; set; } = new();
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }

        public void RemoveTrack(Track track)
        {
            Tracks.Remove(track);
        }

        public void ClearPlaylist()
        {
            Tracks.Clear();
        }

        public void Shuffle()
        {
            Random rng = new();
            int n = Tracks.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (Tracks[k], Tracks[n]) = (Tracks[n], Tracks[k]);
            }
        }

        public Track GetTrack(int index) => Tracks[index];

        public int GetTrackCount() => Tracks.Count;

        public DateTime GetCreationDate() => CreationDate;
    }

    // -------------------- LIBRARY MANAGER --------------------
    public class LibraryManager
    {
        public List<PlaylistCreation> UserLibraries { get; set; } = new();

        public PlaylistCreation CreateLibrary()
        {
            PlaylistCreation newLib = new();
            UserLibraries.Add(newLib);
            return newLib;
        }

        public bool DeleteLibrary(PlaylistCreation library)
        {
            return UserLibraries.Remove(library);
        }

        public PlaylistCreation GetLibrary(int index)
        {
            return UserLibraries[index];
        }

        public int GetLibraryCount()
        {
            return UserLibraries.Count;
        }
    }

    // -------------------- MUSIC CONTROL --------------------
    public class MusicControl
    {
        public int VolumeLevel { get; private set; } = 50;
        public bool IsPlaying { get; private set; }
        public Track CurrentTrack { get; private set; }

        public void Play()
        {
            IsPlaying = true;
            Console.WriteLine("Playing: " + CurrentTrack?.GetInfo());
        }

        public void Pause()
        {
            IsPlaying = false;
            Console.WriteLine("Paused");
        }

        public void Stop()
        {
            IsPlaying = false;
            Console.WriteLine("Stopped");
        }

        public void NextTrack()
        {
            // Placeholder for actual logic
            Console.WriteLine("Skipping to next track...");
        }

        public void PreviousTrack()
        {
            Console.WriteLine("Going to previous track...");
        }

        public void AdjustVolume(int amount)
        {
            VolumeLevel = Math.Clamp(VolumeLevel + amount, 0, 100);
            Console.WriteLine("Volume: " + VolumeLevel);
        }
    }
}
