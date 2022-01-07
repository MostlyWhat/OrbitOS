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

namespace OrbitOS
{
    /// <summary>
    /// Interaction logic for LaunchCenter.xaml
    /// </summary>
    public partial class LaunchCenter : Window
    {
        public LaunchCenter()
        {
            InitializeComponent();
        }

        private async void LaunchProgram(object sender, RoutedEventArgs e)
        {
            string selectedProgram = ProgramSelector.Text;

            if (selectedProgram == "Arithmetic Calculator")
            {
                ArithCalculator arith = new ArithCalculator();
                arith.Show();
            }

            else if (selectedProgram == "Trigonometric Calculator")
            {
                TrigCalculator trig = new TrigCalculator();
                trig.Show();
            }

            else if (selectedProgram == "Text Document Editor")
            {
                TrigCalculator trig = new TrigCalculator();
                trig.Show();
            }

            else if (selectedProgram == "Calendar")
            {
                Calendar calendar = new Calendar();
                calendar.Show();
            }

            else if (selectedProgram == "To-Do List")
            {
                TrigCalculator trig = new TrigCalculator();
                trig.Show();
            }

            else if (selectedProgram == "Web Browser")
            {
                Browser browser = new Browser();
                browser.Show();
            }

            else if (selectedProgram == "Interface Test")
            {
                MainSystem mainsystem = new MainSystem();
                mainsystem.Show();
            }

            else
            {
                var dialog = new NormalDialog("OrbitOS Launch Center", "Please Select an Existing Program to Launch!", "OK");
                await dialog.ShowAsync();
            }
        }
    }
}
