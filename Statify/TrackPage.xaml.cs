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

        public TrackPage(int UserID)
        {
            this.UserId = UserID;
            InitializeComponent();
            DataContext = this;

            InitUI();
        }

        private async void InitUI()
        {
            List<TrackRecord> tracks = await appController.GetTracks(UserId);

            foreach (TrackRecord track in tracks)
            {
                TopTracks.Add(track);
                Console.WriteLine($"{track.Name} - {track.PlayCount}");
            }


            TrackSeries = new ISeries[]
            {    
                new LineSeries<int>()
                {
                    Name = "Songs",
                    Values = tracks.Select(t=>t.PlayCount).ToList()
                }
            };

            TrackChart.Series = TrackSeries;
        }
    }
}
