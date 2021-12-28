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
    /// Interaction logic for NormalDialog.xaml
    /// </summary>
    public partial class NormalDialog : ContentDialog
    {
        public NormalDialog(string inputTitle, string descriptionText, string buttonText)
        {
            InitializeComponent();

            this.Title = inputTitle;
            this.descriptionBox.Text = descriptionText;
            this.CloseButtonText = buttonText;
        }
    }
}
