#region

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using StatifyLib.Data.Models;
using Statifylib.Domain;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for TrackPage.xaml
    /// </summary>
    public partial class TrackPage : Page
    {
        private AppController appController = new();

        public ObservableCollection<TrackRecord> TopTracks { get; private set; } =
            new ObservableCollection<TrackRecord>();

        public ISeries[] TrackSeries { get; set; }

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
                    Values = new int[1] { tracks[i].PlayCount },
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