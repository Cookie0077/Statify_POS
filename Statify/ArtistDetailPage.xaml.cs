<<<<<<< HEAD
﻿using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Statify.Converters;
using Statifylib.Data.Models;
using Statifylib.Domain;
using StatifyLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
=======
﻿#region

>>>>>>> 71d8dfa8b425c191f5ecf37bfc2f1e2b15932239
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
<<<<<<< HEAD
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.System;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
=======
using LiveChartsCore;
using Statify.Converters;
using Statifylib.Data.Models;
using Statifylib.Domain;
>>>>>>> 71d8dfa8b425c191f5ecf37bfc2f1e2b15932239
using Track = Statifylib.Data.Models.Track;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for ArtistDetailPage.xaml
    /// </summary>
    public partial class ArtistDetailPage : Page
    {
        public ISeries[] TrackSeries { get; set; }
        private Artist artist;
<<<<<<< HEAD
        private AppController appController = new AppController();
        private int UserId;

       
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }
        private bool _initialized = false;
        public ArtistDetailPage(Artist artist, int UserId)

=======
        private AppController aoAppController = new AppController();

        public ArtistDetailPage(Artist artist)
>>>>>>> 71d8dfa8b425c191f5ecf37bfc2f1e2b15932239
        {
            InitializeComponent();
            this.UserId = UserId;

            this.artist = artist;
            ImageArtist.Source = new BitmapImage(new Uri(artist.Image));
            LabelArtistName.Content = artist.Name;
            LabelPlaytime.Content = $"{MsToDurationConverter.Convert(artist.Playtime)} Playtime";
            Loaded += Page_Loaded;



            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
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
            List<TrackRecord> tracks = await appController.GetTracksFromArtist(UserId, artist.Id, 10);

            TrackSeries = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Paycount: ",
                    Values = tracks.Select(t => t.PlayCount).ToArray(),
                    Fill = new SolidColorPaint(SKColors.Beige)
                }


            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = tracks.Select(t => t.Name).ToArray(),
                    LabelsRotation = 270
                }
            };
            YAxes = new Axis[]
            {
                new Axis
                {
                    MinStep = 1,
                    ForceStepToMin = true,
                    Labeler = value => value.ToString("N0") 
                }
            };

            TopTracksChart.Series = TrackSeries;
            TopTracksChart.XAxes = XAxes;
            TopTracksChart.YAxes = YAxes;
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
                FileName = artist.URL,
                UseShellExecute = true
            });
        }
    }
}