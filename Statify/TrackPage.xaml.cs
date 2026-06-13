using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Statifylib.Data.Models;
using StatifyLib.Data.Models;
using Statifylib.Data.Services.TrackService;
using Statifylib.Data.Services.UserService;
using Statifylib.Domain;

namespace Statify
{
    /// <summary>
    /// Interaction logic for TrackPage.xaml
    /// </summary>
    public partial class TrackPage : Page
    {
        private AppController appController = new();

        public ObservableCollection<TrackRecord> TopTracks { get; private set; } = new ObservableCollection<TrackRecord>();

        public ISeries[] TrackSeries  { get; set; }

        private int UserId;

        private bool _initialized = false;

        public TrackPage(int UserID)
        {
            this.UserId = UserID;
            InitializeComponent();
            DataContext = this;

            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_initialized) return;
            _initialized = true;

            Loaded -= Page_Loaded;
            InitUI();
        }

        private async void InitUI()
        {
            List<TrackRecord> tracks = await appController.GetTracks(UserId);

            foreach (TrackRecord track in tracks)
            {
                TopTracks.Add(track);
            }


            TrackSeries = new ISeries[tracks.Count];

            for (int i = 0; i < tracks.Count; i++)
            {
                float hue = (i * 65f) % 360f;


                TrackSeries[i] = new PieSeries<int>()
                {
                    Name = tracks[i].Name,
                    Values = new int[1] { tracks[i].PlayCount},
                    // Hue, Saturation, Lightness
                    Fill = new SolidColorPaint(SKColor.FromHsl(hue, 80f, 55f))
                };

                TrackChart.Series = TrackSeries;
            }
            
            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
        }
    }
}
