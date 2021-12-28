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
    /// Interaction logic for TwoButtonDialog.xaml
    /// </summary>
    public partial class TwoButtonDialog : ContentDialog
    {
        public TwoButtonDialog(string inputTitle, string descriptionText, string button1Text, string button2Text, string defaultButton)
        {
            InitializeComponent();

            this.Title = inputTitle;
            this.descriptionBox.Text = descriptionText;
            this.PrimaryButtonText = button1Text;
            this.CloseButtonText = button2Text;

            if (defaultButton == "Primary")
            {
                this.DefaultButton = ContentDialogButton.Primary;
            }

            else if (defaultButton == "Secondary")
            {
                this.DefaultButton = ContentDialogButton.Secondary;
            }

            else if (defaultButton == "Close")
            {
                this.DefaultButton = ContentDialogButton.Close;
            }

            else
            {
                this.DefaultButton = ContentDialogButton.Primary;
            }
        }
    }
}
