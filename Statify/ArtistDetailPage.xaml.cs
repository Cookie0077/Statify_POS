using Statifylib.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveChartsCore;
using Statifylib.Domain;
using Track = Statifylib.Data.Models.Track;

namespace Statify
{
    /// <summary>
    /// Interaction logic for ArtistDetailPage.xaml
    /// </summary>
    public partial class ArtistDetailPage : Page
    {
        public ISeries[] TrackSeries { get; set; }
        private AppController aoAppController = new AppController();
        public ArtistDetailPage(Artist artist)
        {
            InitializeComponent();

            // TODO hier endpoint für die track List
            List<Track> tracks = new List<Track>();
            ImageArtist.Source = new BitmapImage(new Uri(artist.Image));
            LabelArtistName.Content = artist.Name;
            LabelPlaytime.Content = artist.Playtime;

            TrackSeries = new ISeries[tracks.Count];

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService?.CanGoBack == true)
                this.NavigationService.GoBack();
        }
    }
}
