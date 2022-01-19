using System;
using System.Collections.Generic;
using System.IO;
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

namespace OrbitOS.Pages
{
    /// <summary>
    /// Interaction logic for ToDoPage.xaml
    /// </summary>
    public partial class ToDoPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        public static string currentDirectory = Directory.GetCurrentDirectory();
        public static string dirpath = currentDirectory + @"\Config\";
        public static string path = currentDirectory + @"\Config\ToDo.txt";

        private async void AddToDo(object sender, RoutedEventArgs e)
        {
            if (InputData.Text != "")
            {
                string InputString = InputData.Text;
                ToDoListBox.Items.Add(InputString);
                InputData.Text = "";
                ToDoListBox.Focus();
            }
            else
            {
                var dialog = new NormalDialog("OrbitOS To-Do System", "Value must not be Empty!", "OK");
                await dialog.ShowAsync();
            }
        }

        private async void RemoveToDo(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoListBox.Items.RemoveAt(ToDoListBox.SelectedIndex);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                var dialog = new NormalDialog("OrbitOS To-Do System", "Must Select an Existing To-Do", "OK");
                await dialog.ShowAsync();
            }
        }

        private void ClearToDo(object sender, RoutedEventArgs e)
        {
            ToDoListBox.Items.Clear();
        }
    }
}
