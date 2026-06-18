using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Statifylib.Domain;

namespace Statify
{
    /// <summary>
    /// Interaction logic for DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        private AppController appController;
        public DeleteUserWindow(AppController appController)
        {
            InitializeComponent();
            this.appController = appController;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            await appController.DeleteUser();
            this.DialogResult = true;
        }
    }
}
