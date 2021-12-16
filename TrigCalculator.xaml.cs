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
using System.ComponentModel;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Text.RegularExpressions;

namespace OrbitOS
{
    /// <summary>
    /// Interaction logic for TrigCalculator.xaml
    /// </summary>
    public partial class TrigCalculator : MetroWindow
    {
        public TrigCalculator()
        {
            InitializeComponent();

            List<string> NormalTrigList = new List<string>();

            NormalTrigList.Add("Sine Wave");
            NormalTrigList.Add("Cosine Wave");
            NormalTrigList.Add("Tangent Wave");

            NormalTrigSet.ItemsSource = NormalTrigList;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NormalClear(object sender, RoutedEventArgs e)
        {
            angleValue.Text = "";
        }
        private async void NormalCalculate(object sender, RoutedEventArgs e)
        {
            string normalOperator = NormalTrigSet.SelectedItem.ToString();

            if (normalOperator == "Sine Wave")
            {
                try
                {
                    double normalAnswer = Math.Sin(Convert.ToDouble(angleValue.Text));
                    normalOutput.Text = normalAnswer.ToString();
                }
                catch (System.FormatException)
                {
                    await this.ShowMessageAsync("OrbitOS Calculator System", "Values must not be Empty!");
                }
            }

            else if (normalOperator == "Cosine Wave")
            {
                try
                {
                    double normalAnswer = Math.Cos(Convert.ToDouble(angleValue.Text));
                    normalOutput.Text = normalAnswer.ToString();
                }
                catch (System.FormatException)
                {
                    await this.ShowMessageAsync("OrbitOS Calculator System", "Values must not be Empty!");
                }
            }

            else if (normalOperator == "Tangent Wave")
            {
                try
                {
                    double normalAnswer = Math.Tan(Convert.ToDouble(angleValue.Text));
                    normalOutput.Text = normalAnswer.ToString();
                }
                catch (System.FormatException)
                {
                    await this.ShowMessageAsync("OrbitOS Calculator System", "Values must not be Empty!");
                }
            }

            else
            {
                normalOutput.Text = "0";
            }
        }

    }
}
