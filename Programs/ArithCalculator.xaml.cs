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
using ModernWpf.Controls;
using System.Text.RegularExpressions;

namespace OrbitOS
{
    /// <summary>
    /// Interaction logic for ArithCalculator.xaml
    /// </summary>
    public partial class ArithCalculator : Window
    {
        public ArithCalculator()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
                var dialog = new ContentDialog()
                {
                    Title = "OrbitOS Calculator System",
                    Content = "Both Values must not be Empty!",
                    CloseButtonText = "OK",
                    DefaultButton = ContentDialogButton.Close
                };

                await dialog.ShowAsync();
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
                var dialog = new ContentDialog()
                {
                    Title = "OrbitOS Calculator System",
                    Content = "Both Values must not be Empty!",
                    CloseButtonText = "OK",
                    DefaultButton = ContentDialogButton.Close
                };

                await dialog.ShowAsync();
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
                var dialog = new ContentDialog()
                {
                    Title = "OrbitOS Calculator System",
                    Content = "Both Values must not be Empty!",
                    CloseButtonText = "OK",
                    DefaultButton = ContentDialogButton.Close
                };

                await dialog.ShowAsync();
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
                var dialog = new ContentDialog()
                {
                    Title = "OrbitOS Calculator System",
                    Content = "Both Values must not be Empty!",
                    CloseButtonText = "OK",
                    DefaultButton = ContentDialogButton.Close
                };

                await dialog.ShowAsync();
            }
        }
    }
}
