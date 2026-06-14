using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Statifylib.Data.Models;
using Statifylib.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private AppController appController = new AppController();

        public ISeries[] TrackSeries { get; set; }
        
        
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

            SpotfyItemViewTopArtists.GetSpotifyItemList(artists.Cast<SpotifyItem>().ToList(), this.NavigationService);
            SpotfyItemViewTopTracks.GetSpotifyItemList(tracks.Cast<SpotifyItem>().ToList(), this.NavigationService);

            double[] values = tracks.Select(t => (double)t.PlayCount).ToArray();
            // Cuts the track name to 18 characters
            string[] labels = tracks.Select(t => 
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
                    SeparatorsPaint = new SolidColorPaint(new SKColor(255,255,255,40)),
                    MinStep = 1
                }
            };

            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
        }
    }
}