using Serilog;
using Statifylib.Domain;
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
using Statifylib.Data.Models;
using StatifyLib.Data.Models;

namespace Statify
{
    /// <summary>
    /// Interaction logic for ChangeUsernameWindow.xaml
    /// </summary>
    public partial class ChangeUsernameWindow : Window
    {
        private AppController appController;
        public User user;
        public ChangeUsernameWindow(AppController appController)
        {
            InitializeComponent();
            this.appController = appController;


        }

        private async void ButtonConfirm_OnClick(object sender, RoutedEventArgs e)
        {
            string newName = TextBoxNewUsername.Text;

            if (string.IsNullOrEmpty(newName))
            {
                Log.Logger.Error("No Name entered");
                MessageBox.Show("Please enter a Name AND a password");
                return;
            }

            user = await appController.UpdateUser(new UpdateUser(newName));

            if (user.Name == null)
            {
                Log.Logger.Error("false username");
                MessageBox.Show("Try another username");
                return;
            }

            Log.Logger.Information("Updated User succesfully");
            this.DialogResult = true;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
