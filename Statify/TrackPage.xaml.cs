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

namespace Statify
{
    /// <summary>
    /// Interaction logic for TrackPage.xaml
    /// </summary>
    public partial class TrackPage : Page
    {
        private ITrackService trackService;
        
        public ObservableCollection<TrackRecord> TopTracks { get; private set; }

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
            trackService = new TrackServiceFake();

            List<TrackRecord> tracks = await trackService.GetTopTracks(1);
            TopTracks = new ObservableCollection<TrackRecord>(tracks);

            TrackSeries = new ISeries[]
            {    
                new LineSeries<int>()
                {
                    Name = "Plays",
                    // TODO: hier muss der Playcount hin !!
                    Values = tracks.Select(t=>t.PlayCount).ToList()
                }
            };
        }
    }
}
