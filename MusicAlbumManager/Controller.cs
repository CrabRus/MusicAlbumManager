using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MusicAlbumManager
{
    public class Controller
    {
        public Model Model { get; set; }
        public MainWindow View { get; set; }
        public Album SelectedAlbum;
        public List<Track> TempAlbumTracksList;
        public bool AlbumIsOpened = false;
        public Track tempSelectedTrack;

        public Controller(Model model, MainWindow view)
        {
            this.Model = model;
            this.View = view;
            LoadLists();
        }

        public void LoadLists()
        {
            View.trackList.Items.Clear();
            foreach (var track in Model.GetTracks())
            {
                View.trackList.Items.Add($"{track.Name} - {track.Author}");
            }

            View.albumList.Items.Clear();
            foreach (var album in Model.GetAlbums())
            {
                View.albumList.Items.Add($"{album.Title} - {album.Author} - {album.Date}");
            }
        }

        public void AddTrack(string name, string author)
        {
            Track track = new Track()
            {
                Name = name,
                Author = author
            };

            Model.AddTrack(track);
            LoadLists();
        }


        public void AddAlbum(string title, string author)
        {
            Album album = new Album()
            {
                Title = title,
                Author = author,
                Date = DateTime.Today.ToString("M")
            };
            Model.AddAlbum(album);
            LoadLists();
        }

        public void RemoveTrack()
        {
            if (View.trackList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select track to remove.");
            }
            else
            {
                int curIndex = View.trackList.SelectedIndex;
                Model.RemoveTrack(Model.GetTracks()[curIndex]);
                LoadLists();
            }
        }
        public void RemoveAlbum()
        {
            if (View.albumList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select album to remove");
            }
            else
            {
                int curIndex = View.albumList.SelectedIndex;
                Model.RemoveAlbum(Model.GetAlbums()[curIndex]);
                LoadLists();
            }
        }


        public void EditAlbum()
        { 
            if (View.albumList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select album to edit");
            }
            else
            {
                SelectedAlbum = Model.GetAlbums()[View.albumList.SelectedIndex];
                TempAlbumTracksList = SelectedAlbum.GetTracks();
                AlbumIsOpened = true;
                View.EditAlbum.Visibility = Visibility.Visible;
                View.EditAlbum.Header = SelectedAlbum.Title;
                View.editAlbumTitle.Text = SelectedAlbum.Title;
                View.EditAlbumAuthor.Text = SelectedAlbum.Author;
                foreach (var track in SelectedAlbum.GetTracks())
                {
                    View.EditAlbumList.Items.Add($"{track.Name} - {track.Author}");
                }
                View.topTabs.SelectedItem = View.topTabs.Items[2];
            }
        }

        public void SaveAlbum(string newTitle, string newAuthor)
        {
            SelectedAlbum.SetTitle(newTitle);
            SelectedAlbum.SetAuthor(newAuthor);
            SelectedAlbum.SetAlbumTracks(TempAlbumTracksList);

            ExitAlbum();
        }

        public void ExitAlbum()
        {
            View.editAlbumTitle.Clear();
            View.EditAlbumAuthor.Clear();
            SelectedAlbum = null;
            TempAlbumTracksList.Clear();
            AlbumIsOpened = false;
            View.EditAlbum.Visibility = Visibility.Hidden;
            View.topTabs.SelectedItem = View.topTabs.Items[1];
            LoadLists();
        }

        public void AddTrackToAlbum()
        {
            View.topTabs.SelectedItem = View.topTabs.Items[0];
            View.SelectButton.Visibility = Visibility.Visible;
        }

        public void SelectTrack()
        {
            if (View.trackList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select track");
            }
            else
            {
                tempSelectedTrack = Model.GetTracks()[View.trackList.SelectedIndex];
                TempAlbumTracksList.Add(tempSelectedTrack);
                View.EditAlbumList.Items.Add($"{tempSelectedTrack.Name} - {tempSelectedTrack.Author}");
                View.topTabs.SelectedItem = View.topTabs.Items[2];
                View.SelectButton.Visibility = Visibility.Hidden;
            }

        }

        public void RemoveTrackInAlbum()
        {
            if (View.EditAlbumList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select track");
            }
            else
            {
                TempAlbumTracksList.Remove(Model.GetTracks()[View.EditAlbumList.SelectedIndex]);
                View.EditAlbumList.Items.Remove(View.EditAlbumList.SelectedItem);
            }
        }
        
    }

}




