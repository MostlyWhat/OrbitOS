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
    /// Interaction logic for TrigCalculator.xaml
    /// </summary>
    public partial class TrigCalculator
    {
        public TrigCalculator()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // For Normal Calculator
        private void NormalClear(object sender, RoutedEventArgs e)
        {
            angleValue.Text = "";
        }
        private async void NormalCalculate(object sender, RoutedEventArgs e)
        {
            string normalOperator = NormalTrigSet.Text;

            if (normalOperator == "Sine Wave - sin()")
            {
                try
                {
                    double normalAnswer = Math.Sin(Convert.ToDouble(angleValue.Text));
                    normalOutput.Text = normalAnswer.ToString();
                }
                catch (System.FormatException)
                {
                    var dialog = new NormalDialog("OrbitOS Calculator System", "Selector and Degrees must not be Empty!", "OK");
                    await dialog.ShowAsync();
                }
            }

            else if (normalOperator == "Cosine Wave - cos()")
            {
                try
                {
                    double normalAnswer = Math.Cos(Convert.ToDouble(angleValue.Text));
                    normalOutput.Text = normalAnswer.ToString();
                }
                catch (System.FormatException)
                {
                    var dialog = new NormalDialog("OrbitOS Calculator System", "Selector and Degrees must not be Empty!", "OK");
                    await dialog.ShowAsync();
                }
            }

            else if (normalOperator == "Tangent Wave - tan()")
            {
                try
                {
                    double normalAnswer = Math.Tan(Convert.ToDouble(angleValue.Text));
                    normalOutput.Text = normalAnswer.ToString();
                }
                catch (System.FormatException)
                {
                    var dialog = new NormalDialog("OrbitOS Calculator System", "Selector and Degrees must not be Empty!", "OK");
                    await dialog.ShowAsync();
                }
            }

            else
            {
                normalOutput.Text = "0";
            }
        }

        // For Arc Operations
    }
}
