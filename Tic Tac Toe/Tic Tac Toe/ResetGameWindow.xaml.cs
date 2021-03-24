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

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for ResetGameWindows.xaml
    /// </summary>
    public partial class ResetGameWindow : Window
    {
        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }
        public ResetGameWindow(string result)
        {
            Result = result;
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
