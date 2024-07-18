using System.Diagnostics.Contracts;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicAlbumManager
{
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            Model model = new Model();
            controller = new Controller(model, this);
        }
        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            if (trackName.Text == "" || trackAuthor.Text == "")
            {
                MessageBox.Show("Please check the text fields");
            }
            else
            {
                controller.AddTrack(trackName.Text, trackAuthor.Text);
                trackName.Clear();
                trackAuthor.Clear();
            }
            
        }

        private void AddAlbum_Click(object sender, RoutedEventArgs e)
        {
            if (albumTitle.Text == "" || albumAuthor.Text == "")
            {
                MessageBox.Show("Please check the text fields");
            }
            else
            {
                controller.AddAlbum(albumTitle.Text, albumAuthor.Text);
                albumTitle.Clear();
                albumAuthor.Clear();
            }

        }

        private void RemoveTrack_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveTrack();
        }

        private void RemoveAlbum_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveAlbum();
        }

        private void EditAlbum_Click(object sender, RoutedEventArgs e)
        {
            controller.EditAlbum();
        }

        private void SaveAlbum_Click(Object sender, RoutedEventArgs e)
        {
            if (editAlbumTitle.Text == "" || EditAlbumAuthor.Text == "")
            {
                MessageBox.Show("Please check the text fields");
            }
            else
            {
                controller.SaveAlbum(editAlbumTitle.Text, EditAlbumAuthor.Text);
            }
                
        }

        private void ExitAlbum_Click(Object sender, RoutedEventArgs e)
        {
            controller.ExitAlbum();
        }

        private void AddAlbumsTrack_Click(object sender, RoutedEventArgs e)
        {
            controller.AddTrackToAlbum();
        }

        private void RemoveAlbumsTrack_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveTrackInAlbum();
        }

        private void SelectTrack_Click(Object sender, RoutedEventArgs e)
        {
            controller.SelectTrack();
        }
    }
}