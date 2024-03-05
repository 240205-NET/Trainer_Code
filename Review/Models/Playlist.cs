namespace Models;

public class Playlist {
    public string Name { get; set; }
    public string Creator { get; set; }
    public List<Track> tracks { get; set; }

    public override string ToString() {
        return base.ToString();
    }
}