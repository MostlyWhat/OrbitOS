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
    /// Interaction logic for MainSystem.xaml
    /// </summary>
    public partial class MainSystem : Window
    {
        public MainSystem()
        {
            InitializeComponent();
        }

        private void NavigationPage_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Pages.HomePage));
        }

        private void NavigationPage_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(Pages.SettingsPage));
            }
            else
            {
                var NavselectedItem = (NavigationViewItem)args.SelectedItem;
                string selectedItem = NavselectedItem.Tag as string;

                if (selectedItem != null)
                {
                    if (selectedItem == "HomePage")
                    {
                        contentFrame.Navigate(typeof(Pages.HomePage));
                    }

                    else if (selectedItem == "ArithCalculator")
                    {
                        contentFrame.Navigate(typeof(Pages.ArithCalculator));
                    }

                    else if (selectedItem == "TrigCalculator")
                    {
                        contentFrame.Navigate(typeof(Pages.TrigCalculator));
                    }
                }
            }
        }

        private void NavigationPage_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {

        }
    }
}
