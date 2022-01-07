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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModernWpf.Controls;
using System.Text.RegularExpressions;

namespace OrbitOS.Pages
{
    /// <summary>
    /// Interaction logic for ArithCalculator.xaml
    /// </summary>
    public partial class ArithCalculator
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
                var dialog = new NormalDialog("OrbitOS Calculator System", "Both Values must not be Empty!", "OK");
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
                var dialog = new NormalDialog("OrbitOS Calculator System", "Both Values must not be Empty!", "OK");
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
                var dialog = new NormalDialog("OrbitOS Calculator System", "Both Values must not be Empty!", "OK");
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
                var dialog = new NormalDialog("OrbitOS Calculator System", "Both Values must not be Empty!", "OK");
                await dialog.ShowAsync();
            }
        }
    }
}
