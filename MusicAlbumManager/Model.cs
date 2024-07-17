namespace MusicAlbumManager
{
    public class Track
    {
        public string Name {  get; set; }
        public string Author {  get; set; }
    }
    public class Album
    {
        public string Title {  get; set; }
        public string Author { get; set; }
        public string Date {  get; set; }
        private List<Track> albumTracks = new List<Track> { };

        public List<Track> GetTracksFromAlbum()
        {
            return albumTracks;
        }
        public void SetTitle(string newTitle)
        {
            Title = newTitle;
        }
        public void SetAuthor(string newAuthor)
        {
            Author = newAuthor;
        }
        public void SetAlbumTracks(List<Track> newAlbumTracks)
        {
            albumTracks = newAlbumTracks;
        }
    }
    public class Model
    {
        private List<Track> tracks = new List<Track> { };
        private List<Album> albums = new List<Album> { };

        public List<Track> GetTracks()
        {
            return tracks;
        }
        public List<Album> GetAlbums()
        {
            return albums;
        }



        public void AddTrack(Track track)
        {
            tracks.Add(track);
        }
        public void RemoveTrack(Track track)
        {
            tracks.Remove(track);
        }



        public void AddAlbum(Album album)
        {
            albums.Add(album);
        }
        public void RemoveAlbum(Album album)
        {
            albums.Remove(album);
        }



        public void AddTrackInAlbum(Track track, Album album)
        {
            //album.albumTracks.Add(track);
        }
        public void RemoveTrackInAlbum(Track track,Album album)
        {
            //album.albumTracks.Remove(track);
        }


    }
}
