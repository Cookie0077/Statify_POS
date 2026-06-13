using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using StatifyLib.Data.Models;

namespace Statify
{
    /// <summary>
    /// Interaction logic for TrackDetailPage.xaml
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
            LabelArtistName.Content = $"Artist: {track.Name}";
            LabelDuration.Content = $"Duration: {track.Duration}";
            LabelLastplayed.Content = $"Last Played: {track.LastPlayed}";
            LabelPlaycount.Content = $"Played: {track.PlayCount}x";

            
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
                FileName =track.URL,
                UseShellExecute = true
            });
        }
    }
}
