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
    private Appview appview;
    public MainWindow()
    {
        InitializeComponent();
        appview = new Appview(this);
        appview.InitUI();
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl tabControl)
        {
            TabItem ausgewaehlterTab = tabControl.SelectedItem as TabItem;

            // TODO: SWITCH für den Tab.name und dann ins neue Page wechseln
            
        }
    }
}