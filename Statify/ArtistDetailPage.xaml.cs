#region

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using LiveChartsCore;
using Statify.Converters;
using Statifylib.Data.Models;
using Statifylib.Domain;
using Track = Statifylib.Data.Models.Track;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for ArtistDetailPage.xaml
    /// </summary>
    public partial class ArtistDetailPage : Page
    {
        public ISeries[] TrackSeries { get; set; }
        private Artist artist;
        private AppController aoAppController = new AppController();

        public ArtistDetailPage(Artist artist)
        {
            InitializeComponent();

            // TODO hier endpoint für die track List
            this.artist = artist;
            List<Track> tracks = new List<Track>();
            ImageArtist.Source = new BitmapImage(new Uri(artist.Image));
            LabelArtistName.Content = artist.Name;
            LabelPlaytime.Content = $"{MsToDurationConverter.Convert(artist.Playtime)} Playtime";

            TrackSeries = new ISeries[tracks.Count];

            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService?.CanGoBack == true)
                this.NavigationService.GoBack();
        }

        private void ButtonViewOnSpotify_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = artist.URL,
                UseShellExecute = true
            });
        }
    }
}