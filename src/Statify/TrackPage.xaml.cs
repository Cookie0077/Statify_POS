#region

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Serilog;
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
        public AppController appController = new();

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
            
            
            TrackRecord[] TopTenTracks = tracks
                .OrderByDescending(t => t.PlayCount)
                .Take(10)
                .ToArray();
            
            double[] values = TopTenTracks.Select(t => (double)t.PlayCount).ToArray();
            // Cuts the track name to 18 characters
            string[] labels = TopTenTracks.Select(t =>
                t.Name.Length > 18 ? t.Name.Substring(0, 16) + "…" : t.Name
            ).ToArray();

            values = values.Reverse().ToArray();
            labels = labels.Reverse().ToArray();

            TrackSeries = new ISeries[]
            {
                new RowSeries<double>
                {
                    Values = values,
                    Fill = new SolidColorPaint(new SKColor(242, 211, 171))
                }
            };

            TrackChart.Series = TrackSeries;
            TrackChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,
                    TextSize = 13,
                    LabelsPaint = new SolidColorPaint(SKColors.LightGray)
                }
            };
            TrackChart.XAxes = new Axis[]
            {
                new Axis
                {
                    TextSize = 12,
                    LabelsPaint = new SolidColorPaint(SKColors.LightGray),
                    SeparatorsPaint = new SolidColorPaint(new SKColor(255, 255, 255, 40)),
                    MinStep = 1
                }
            };

            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
            
            Log.Logger.Information("Loaded Track Page");
        }

        private void ListViewTracks_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TrackRecord chosenTrack = ListViewTracks.SelectedItem as TrackRecord;

            TrackDetailPage trackDetailPage = new TrackDetailPage(chosenTrack);
            
            this.NavigationService.Navigate(trackDetailPage);
        }
    }
}