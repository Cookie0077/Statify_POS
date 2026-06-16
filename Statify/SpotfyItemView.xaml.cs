#region

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Statifylib.Data.Models;
using StatifyLib.Data.Models;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for SpotfyItemView.xaml
    /// </summary>
    public partial class SpotfyItemView : UserControl
    {
        public ObservableCollection<SpotifyItem> SpotifyItems { get; private set; } =
            new ObservableCollection<SpotifyItem>();

        public ObservableCollection<Image> Item_Images { get; private set; } = new ObservableCollection<Image>();

        private NavigationService _navigationService;

        private int UserId;


        public SpotfyItemView()
        {
            InitializeComponent();
            DataContext = this;
        }

<<<<<<< HEAD
        public void GetSpotifyItemList(List<SpotifyItem> spotifyItems,NavigationService parenNavigationService,int UserId)
=======
        public void GetSpotifyItemList(List<SpotifyItem> spotifyItems, NavigationService parenNavigationService)
>>>>>>> 71d8dfa8b425c191f5ecf37bfc2f1e2b15932239
        {
            this.UserId = UserId;
            _navigationService = parenNavigationService;
            foreach (SpotifyItem item in spotifyItems)
            {
                SpotifyItems.Add(item);
                if (item.Image == null)
                    continue;

                Image Track_image = new Image()
                {
                    Source = new BitmapImage(new Uri(item.Image)),
                    Width = 40,
                    Height = 40,
                    Stretch = Stretch.Uniform,
                };
                Item_Images.Add(Track_image);
            }

            if (Item_Images.Count == 0)
            {
                ListViewImages.Visibility = Visibility.Hidden;
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpotifyItem item = ListviewItems.SelectedItem as SpotifyItem;
            if (_navigationService == null) return;

            if (item is TrackRecord)
            {
                _navigationService.Navigate(new TrackDetailPage(item as TrackRecord));
            }

            if (item is Artist)
            {
                _navigationService.Navigate(new ArtistDetailPage(item as Artist,UserId));
            }

            if (item is Playlist)
            {
                _navigationService.Navigate(new PlaylistDetailPage(item as Playlist,UserId));
            }
        }

        public void Clear()
        {
            Item_Images.Clear();
            SpotifyItems.Clear();
        }


        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer == null) return;

            // Adjust vertical offset based on delta
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
            e.Handled = true; // Prevent default behavior
        }
    }
}