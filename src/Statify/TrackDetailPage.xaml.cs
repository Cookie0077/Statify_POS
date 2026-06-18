#region

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Serilog;
using Statify.Converters;
using StatifyLib.Data.Models;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for TrackDetailPage.xaml
    /// </summary>
    public partial class TrackDetailPage : Page
    {
        private TrackRecord track;

        public TrackDetailPage(TrackRecord track)
        {
            InitializeComponent();
            this.track = track;

            ImageTrack.Source = new BitmapImage(new Uri(track.Image));
            LabelTitel.Content = track.Name;
            LabelArtistName.Content = $"Artist: {track.Artist}";
            LabelDuration.Content = $"Duration: {MsToDurationConverter.Convert(track.Duration)}";
            LabelLastplayed.Content = $"Last Played: {track.LastPlayed}";
            LabelPlaycount.Content = $"Played: {track.PlayCount} {(track.PlayCount == 1 ? "Time" : "Times")}";


            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
            Log.Logger.Information("Loaded Track Detail Page");
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService?.CanGoBack == true)
                this.NavigationService.GoBack();
        }

        private void ButtonViewOnSpotify_Click(object sender, RoutedEventArgs e)
        {
            Log.Logger.Information("Viewing Track on Spotify");
            Process.Start(new ProcessStartInfo()
            {
                FileName = track.URL,
                UseShellExecute = true
            });
        }
    }
}