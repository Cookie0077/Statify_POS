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

namespace Statify;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private MainPage main = new MainPage();
    public MainWindow()
    {
        InitializeComponent();
        Mainframe.Navigate(main);
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl tabControl)
        {
            TabItem selectedTab = tabControl.SelectedItem as TabItem;

           switch(selectedTab.Name)
            {
                case "TabHome":
                    Mainframe.Navigate(main);
                    break;

                case "ArtistTab":
                    Mainframe.Navigate(new ArtistPage());
                    break;


                case "SongTabs":
                    Mainframe.Navigate(new TrackPage());
                    break;


                case "PlaylistTab":
                   Mainframe.Navigate(new PlaylistPage());
                   break;



            }
            
        }
    }
}