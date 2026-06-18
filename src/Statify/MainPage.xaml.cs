#region

using System.Windows;
using System.Windows.Controls;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Serilog;
using SkiaSharp;
using Statifylib.Data.Models;
using StatifyLib.Data.Models;
using Statifylib.Domain;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public AppController appController = new AppController();

        public ISeries[] DailyListeningSeries { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }


        private int UserId;

        private bool _initialized;

        public MainPage(int userId)
        {
            InitializeComponent();
            UserId = userId;
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


        public async void InitUI()
        {
            await appController.SyncUser(UserId);
            List<Artist> artists = await appController.GetTopArtists(UserId);
            List<TrackRecord> tracks = await appController.GetTopTracks(UserId);

            SpotfyItemViewTopArtists.GetSpotifyItemList(artists.Cast<SpotifyItem>().ToList(), this.NavigationService,UserId);
            SpotfyItemViewTopTracks.GetSpotifyItemList(tracks.Cast<SpotifyItem>().ToList(), this.NavigationService,UserId);

            
            /* propmt: make me the chart for the mainpage so that it shows a linechart. Each day shows how much minutes you listened. I get this by using a function which returns a List of a dict/class with 
                duration
                day
                make that pls
            */
            List<DailyListening> dailyData = await appController.GetDailyListening(UserId);

            // sort by date ascending so the line reads left-to-right chronologically
            List<DailyListening> sorted = dailyData.OrderBy(d => d.Timestamp).ToList();

            double[] minutesPerDay = sorted.Select(d => (double)(d.Playtime / 60000)).ToArray();
            string[] dayLabels = sorted.Select(d => d.Timestamp.ToString("MMM d")).ToArray();

            DailyListeningSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Minutes listened",
                    Values = minutesPerDay,
                    Fill = null,                                    // no area fill under the line
                    Stroke = new SolidColorPaint(SKColors.Beige, 3) // line color + thickness
                }
            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = dayLabels,
                    LabelsRotation = 45,
                    TextSize = 12,
                    LabelsPaint = new SolidColorPaint(SKColors.LightGray)
                }
            };

            DailyChart.Series = DailyListeningSeries;
            DailyChart.XAxes = XAxes;

            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
            
            Log.Logger.Information("Loaded Main Page");
        }
    }
}