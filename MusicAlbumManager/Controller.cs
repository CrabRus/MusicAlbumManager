using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MusicAlbumManager
{
    public class Controller
    {
        public Model Model { get; set; }
        public MainWindow View { get; set; }
        public Album SelectedAlbum;
        public List<Track> TempAlbumTracksList;
        public bool AlbumIsOpened = false;

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
            SelectedAlbum = Model.GetAlbums()[View.albumList.SelectedIndex];
            TempAlbumTracksList = SelectedAlbum.GetTracksFromAlbum();
            AlbumIsOpened = true;
            var listbox = new ListBox
            {
                Height = 200
            };
            foreach (var track in SelectedAlbum.GetTracksFromAlbum())
            {
                listbox.Items.Add($"{track.Name} - {track.Author}");
            }
            View.topTabs.Items.Add(new TabItem
            {
                Name = "openedAlbumTab",
                Header = SelectedAlbum.Title,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                Content = new StackPanel
                {
                    Children =
                    {
                        new TextBlock
                        {
                            Text = "Title",
                            FontSize = 15,
                            FontWeight = FontWeights.DemiBold
                        },
                        new TextBox
                        {
                            Name = "newTitle",
                            Text = SelectedAlbum.Title,
                            Margin = new Thickness(0,0,0,5)
                        },
                        new TextBlock
                        {
                            Text = "Author",
                            FontSize = 15,
                            FontWeight = FontWeights.DemiBold
                        },
                        new TextBox
                        {
                            Name="newAuthor",
                            Text = SelectedAlbum.Author,
                            Margin = new Thickness(0,0,0,5)
                        },
                        listbox,
                        new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Margin = new Thickness(10),
                            Children =
                            {
                                new Button
                                {
                                    Name = "SaveButton",
                                    Content = "Save",
                                    Click = "" 
                                },
                                new Button
                                {
                                    Name = "ExitButton",
                                    Content = "Exit",
                                    Margin = new Thickness(20,0,0,0)
                                }
                            }
                        }
                    }
                }

            });

        }

        public void SaveAlbum(string newTitle, string newAuthor, List<Track> newAlbumTracks)
        {
            SelectedAlbum.SetTitle(newTitle);
            SelectedAlbum.SetAuthor(newAuthor);
            SelectedAlbum.SetAlbumTracks(newAlbumTracks);

            SelectedAlbum = null;
            TempAlbumTracksList = null;
            AlbumIsOpened = false;

            View.topTabs.Items.Remove(View.topTabs.FindName("openedAlbumTab") as TabItem);
            
        }
        
    }

}




