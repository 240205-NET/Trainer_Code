namespace Models;

public class Track
{
    public Track() { }
    public Track(int id) {
        TrackId = id;
    }
    public Track(int id, string trackName) : this(id) {
        TrackName = trackName;
    }
    public Track(string trackName, int id) : this(id) {
        TrackName = trackName;
    }
    public int TrackId { get; set; }
    public string ArtistName { get; set; }
    public string TrackName { get; set; }
    public string Genre { get; set; }
    public TimeSpan TrackLength { get; set; }

    public override string ToString() {
        return $"TrackId: {TrackId} \nArtist Name: {ArtistName} \nTrack Name: {TrackName} \nGenre: {Genre} \nLength: {TrackLength}";
    }
}
