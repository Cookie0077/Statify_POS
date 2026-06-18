#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Serilog;
using Statifylib.Data.Models;
using Statifylib.Domain;

#endregion

namespace Statify;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private MainPage mainPage;
    private ArtistPage artistPage;
    private TrackPage trackPage;
    private PlaylistPage playlistPage;
    private User CurentUser;

    private bool loginwindowoff = false;

    private AppController appController = new AppController();
    private DispatcherTimer timer;
    private bool isTimerRunning;

    public MainWindow()
    {
        InitializeComponent();

        if (!loginwindowoff)
        {
            LoginWindow loginWindow = new LoginWindow(appController);
            if (loginWindow.ShowDialog() == true)
            {
                CurentUser = loginWindow.UserAPI;
                mainPage = new MainPage(appController);
                artistPage = new ArtistPage(appController);
                trackPage = new TrackPage(appController);
                playlistPage = new PlaylistPage(appController);
                Labelusername.Content = CurentUser.Name;
                if (CurentUser.Image == null)
                    ImageProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/user.png"));

                else
                    ImageProfile.Source = new BitmapImage(new Uri(CurentUser.Image));
                Log.Logger.Debug("Initialized with login");
                Log.Logger.Information("User logged in: {Name}", CurentUser.Name);
            }
        }
        else
        {
            mainPage = new MainPage(appController);
            artistPage = new ArtistPage(appController);
            trackPage = new TrackPage(appController);
            playlistPage = new PlaylistPage(appController);
            Log.Logger.Debug("Initialized without login");
        }

        Mainframe.Navigate(mainPage);

        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(30);
        timer.Tick += (s, e) =>
        {
            isTimerRunning = false;
            timer.Stop();
        };
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl tabControl)
        {
            TabItem selectedTab = tabControl.SelectedItem as TabItem;

            switch (selectedTab.Name)
            {
                case "TabHome":
                    Mainframe.Navigate(mainPage);
                    Log.Logger.Debug("Navigated to Home");
                    break;

                case "ArtistTab":
                    Mainframe.Navigate(artistPage);
                    Log.Logger.Debug("Navigated to Artists");
                    break;


                case "SongTabs":
                    Mainframe.Navigate(trackPage);
                    Log.Logger.Debug("Navigated to Songs");
                    break;


                case "PlaylistTab":
                    Mainframe.Navigate(playlistPage);
                    Log.Logger.Debug("Navigated to Playlists");
                    break;
            }
        }
    }

    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Labelusername_Click(object sender, RoutedEventArgs e)
    {
        UserDropdownPopup.IsOpen = !UserDropdownPopup.IsOpen;
    }

    private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
    {
        UserDropdownPopup.IsOpen = false;

        this.Hide(); 

        LoginWindow loginWindow = new LoginWindow(appController);
        if (loginWindow.ShowDialog() == true)
        {
            CurentUser = loginWindow.UserAPI;
            mainPage = new MainPage(appController);
            artistPage = new ArtistPage(appController);
            trackPage = new TrackPage(appController);
            playlistPage = new PlaylistPage(appController);
            Labelusername.Content = CurentUser.Name;

            if (CurentUser.Image == null)
                ImageProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/user.png"));
            else
                ImageProfile.Source = new BitmapImage(new Uri(CurentUser.Image));

            Log.Logger.Information("User logged in: {Name}", CurentUser.Name);
            Mainframe.Navigate(mainPage); 
            this.Show(); 
        }
    }


    private void ButtonChangeName_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeUsernameWindow usernameWindow = new ChangeUsernameWindow(appController);

        if (usernameWindow.ShowDialog() == true)
        {
            this.CurentUser = usernameWindow.user;
            Labelusername.Content = CurentUser.Name;
        }
    }


    private async void ButtonRefreshUserTable_Click(object sender, RoutedEventArgs e)
    {
        if (isTimerRunning)
        {
            Log.Logger.Warning("Timer already running");
            return;
        }
        
        isTimerRunning = true;
        timer.Start();
        
        object curPage = Mainframe.Content;
        await mainPage.appController.SyncUser();
        Log.Logger.Information("TrackRecord Table refreshed");
    }

    private void ButtonDeleteAccount_OnClick(object sender, RoutedEventArgs e)
    {
        DeleteUserWindow deletwindow = new DeleteUserWindow(appController);

        if (deletwindow.ShowDialog()== true)
        {
            UserDropdownPopup.IsOpen = false;

            this.Hide();

            LoginWindow loginWindow = new LoginWindow(appController);
            if (loginWindow.ShowDialog() == true)
            {
                CurentUser = loginWindow.UserAPI;
                mainPage = new MainPage(appController);
                artistPage = new ArtistPage(appController);
                trackPage = new TrackPage(appController);
                playlistPage = new PlaylistPage(appController);
                Labelusername.Content = CurentUser.Name;

                if (CurentUser.Image == null)
                    ImageProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/user.png"));
                else
                    ImageProfile.Source = new BitmapImage(new Uri(CurentUser.Image));

                Log.Logger.Information("User logged in: {Name}", CurentUser.Name);
                Mainframe.Navigate(mainPage);
                this.Show();
            }
        }
    }
}