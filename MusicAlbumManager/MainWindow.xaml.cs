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
            controller.AddTrack(trackName.Text, trackAuthor.Text);
            trackName.Clear();
            trackAuthor.Clear();
        }

        private void AddAlbum_Click(object sender, RoutedEventArgs e)
        {
            controller.AddAlbum(albumName.Text, albumAuthor.Text);
            albumName.Clear();
            albumAuthor.Clear();
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
            var tabItem = topTabs.FindName("openedAlbum") as TabItem;
            var newTitleTextBox = tabItem.FindName("newTitle") as TextBox;
            var newAuthorTextBox = tabItem.FindName("newAuthor") as TextBox;

            string newTitle = newTitleTextBox.Text;
            string newAuthor = newAuthorTextBox.Text;

            controller.SaveAlbum(newTitle, newAuthor, controller.TempAlbumTracksList);
        }
    }
}