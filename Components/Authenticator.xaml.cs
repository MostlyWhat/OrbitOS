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
    /// Interaction logic for BootLoader.xaml
    /// </summary>
    public partial class Authenticator : ContentDialog
    {
        public Authenticator()
        {
            InitializeComponent();
        }

        public string Username
        {
            get { return (AuthUsername.Text).ToString(); }
            set { AuthUsername.Text = value; }
        }

        public string Password
        {
            get { return (AuthPassword.Password).ToString(); }
            set { AuthPassword.Password = value; }
        }
    }
}
