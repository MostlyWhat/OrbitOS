using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
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
using System.ComponentModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace OrbitOS
{
    /// <summary>
    /// Interaction logic for BootLoader.xaml
    /// </summary>
    public partial class BootLoader : MetroWindow
    {
        public BootLoader()
        {
            InitializeComponent();
            InitialLaunch();
            InitialLogin();
        }

        string adminUsername = "admin";
        string adminPassword = "admin";

        private void InitialLaunch()
        {
            usernameLabel.Content = Environment.UserName;
            contentLocker.Visibility = System.Windows.Visibility.Visible;
            
        }

        private async void InitialLogin()
        {
            LoginDialogData loginData = await this.ShowLoginAsync("OrbitOS Portal Authentication", "Please Input OrbitOS's Administrator Authentication Code (Enter Nothing to Exit)");

            if (loginData.Username == adminUsername && loginData.Password == adminPassword)
            {
                await this.ShowMessageAsync("OrbitOS Portal Authentication", "Success, Correct Credentials...Starting Program");
                contentLocker.Visibility = System.Windows.Visibility.Hidden;
            }

            else
            {
                await this.ShowMessageAsync("OrbitOS Portal Authentication", "Failure, Invalid Credentials...Exiting Program");
                Application.Current.Shutdown();
            }
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void logoutButton(object sender, RoutedEventArgs e)
        {
            contentLocker.Visibility = System.Windows.Visibility.Visible;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Hide();
            InitialLogin();
        }

        private void openInterface(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }


        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://www.github.com/mostlywhat/orbitos");
        }

        private void ReportIssues(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://www.github.com/mostlywhat/orbitos/issues");
        }

        private void BootLoaderClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
