namespace Models;

public class RamStorage {
    public static List<Track> tracks = new() {
        // Object Initializer Syntax
        new Track {
            TrackId = 1,
            TrackName = "What have I done to deserve this",
            ArtistName = "Pet Shop Boys",
            Genre = "Synth Pop/Alternative",
            TrackLength = new TimeSpan(0, 4, 22)
        },
        new Track {
            TrackId = 2,
            TrackName = "New Year's Day",
            ArtistName = "U2",
            Genre = "Rock",
            TrackLength = new TimeSpan(0, 5, 35)
        },
        new Track {
            TrackId = 3,
            TrackName = "Santeria",
            ArtistName = "Sublime",
            Genre = "Ska Punk",
            TrackLength = new TimeSpan(0, 3, 3)
        }
    };
    public static List<Playlist> playlists = new() {

    };
}