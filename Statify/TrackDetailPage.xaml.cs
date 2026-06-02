using System;
using System.Collections.Generic;
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
        public TrackDetailPage(TrackRecord track)
        {
            InitializeComponent();

            ImageTrack.Source = new BitmapImage(new Uri(track.Image));
            LabelTitel.Content = track.Name;
            LabelArtistName.Content = $"Artist: {track.Name}";
            LabelDuration.Content = $"Duration: {track.Duration}";
            LabelLastplayed.Content = $"Last Played: {track.LastPlayed}";
            LabelPlaycount.Content = $"Played {track.PlayCount}X";


        }
    }
}
