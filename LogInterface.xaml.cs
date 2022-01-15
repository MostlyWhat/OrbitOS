using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ModernWpf.Controls;

namespace OrbitOS
{
    /// <summary>
    /// Interaction logic for LogInterface.xaml
    /// </summary>
    public partial class LogInterface : Window
    {
        public LogInterface()
        {
            InitializeComponent();
            InitialLaunch();
            LoginWindow();
        }

        public void InitialLaunch()
        {
            usernameLabel.Content = Environment.UserName;
            contentLocker.Visibility = System.Windows.Visibility.Visible;
        }

        /// Login Information
        string adminUsername = "admin";
        string adminPassword = "admin";
        private async void LoginWindow()
        {
            Authenticator auth = new Authenticator();
            var authResult = await auth.ShowAsync();

            if (authResult == ContentDialogResult.Primary)
            {
                if (auth.Username == adminUsername && auth.Password == adminPassword)
                {
                    var dialog = new NormalDialog("OrbitOS Portal Authentication", "Success, Correct Credentials...Starting Program!", "OK");
                    await dialog.ShowAsync();

                    contentLocker.Visibility = System.Windows.Visibility.Hidden;
                }

                else
                {

                    var dialog = new TwoButtonDialog("OrbitOS Portal Authentication", "Failure, Invalid Credentials...Locking Program!", "Retry", "Exit", "Close");
                    var result = await dialog.ShowAsync();

                    if (result == ContentDialogResult.Primary)
                    {
                        LoginWindow();
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }
                }

            }

            else
            {
                var dialog = new TwoButtonDialog("OrbitOS Portal Authentication", "Exiting, Are you Sure?", "Exit", "Cancel", "Primary");
                var result = await dialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    LoginWindow();
                }
            }
        }
        private void logoutButton(object sender, RoutedEventArgs e)
        {
            contentLocker.Visibility = System.Windows.Visibility.Visible;
            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            LoginWindow();
        }

        private void openInterface(object sender, RoutedEventArgs e)
        {
            MainSystem mainsystem = new MainSystem();
            mainsystem.Show();
        }

        private void ClosingProgram(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
