#region

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Serilog;
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

        public void GetSpotifyItemList(List<SpotifyItem> spotifyItems,NavigationService parenNavigationService,int UserId)

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
                Log.Logger.Information("TrackRecord selected");
                _navigationService.Navigate(new TrackDetailPage(item as TrackRecord));
            }

            if (item is Artist)
            {
                Log.Logger.Information("Artist selected");
                _navigationService.Navigate(new ArtistDetailPage(item as Artist,UserId));
            }

            if (item is Playlist)
            {
                Log.Logger.Information("Playlist selected");
                _navigationService.Navigate(new PlaylistDetailPage(item as Playlist,UserId));
            }

            if (item is Track)
            {
                Log.Logger.Information("Track selected");
                Process.Start(new ProcessStartInfo()
                {
                    FileName = item.URL,
                    UseShellExecute = true
                });
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