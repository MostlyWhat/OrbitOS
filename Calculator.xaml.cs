using System;
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
using System.Diagnostics;
using System.Runtime.InteropServices;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Text.RegularExpressions;

namespace OrbitOS
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : MetroWindow
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://www.github.com/mostlywhat/orbitos");
        }

        private void ReportIssues(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://www.github.com/mostlywhat/orbitos/issues");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            AdvancedBox.Text = "";
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void simpleClear_Click(object sender, RoutedEventArgs e)
        {
            value1.Text = "";
            value2.Text = "";
            simpleValue.Text = "";
        }

        private async void simpleAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value1Var = Convert.ToDouble(value1.Text);
                double value2Var = Convert.ToDouble(value2.Text);
                double addSum = value1Var + value2Var;
                simpleValue.Text = addSum.ToString();
            }
            catch (System.FormatException)
            {
                await this.ShowMessageAsync("OrbitOS Calculator System", "Both Values must not be Empty!");
            }
        }

        private async void simpleSub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value1Var = Convert.ToDouble(value1.Text);
                double value2Var = Convert.ToDouble(value2.Text);
                double addSum = value1Var - value2Var;
                simpleValue.Text = addSum.ToString();
            }
            catch (System.FormatException)
            {
                await this.ShowMessageAsync("OrbitOS Calculator System", "Both Values must not be Empty!");
            }
        }

        private async void simpleMul_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value1Var = Convert.ToDouble(value1.Text);
                double value2Var = Convert.ToDouble(value2.Text);
                double addSum = value1Var * value2Var;
                simpleValue.Text = addSum.ToString();
            }
            catch (System.FormatException)
            {
                await this.ShowMessageAsync("OrbitOS Calculator System", "Both Values must not be Empty!");
            }
        }

        private async void simpleDiv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value1Var = Convert.ToDouble(value1.Text);
                double value2Var = Convert.ToDouble(value2.Text);
                double addSum = value1Var / value2Var;
                simpleValue.Text = addSum.ToString();
            }
            catch (System.FormatException)
            {
                await this.ShowMessageAsync("OrbitOS Calculator System", "Both Values must not be Empty!");
            }
        }
    }
}
