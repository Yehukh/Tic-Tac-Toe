using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Tic_Tac_Toe.Refresheres;

namespace Tic_Tac_Toe.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {

        public SettingsPage()
        {
            InitializeComponent();
            if (UserVsBotGameplay.UserVsBot)
            {
                BotButton.IsChecked = true;
            }
            else
            {
                UserButton.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32.TryParse(Nrows.Text, out int rows);
                if (rows >= 3 && rows <= 20)
                {
                    var cell = Board.Cells.FirstOrDefault(x => x.Sign != null);
                    if (cell != null) UpdateBoard.Update();
                    Board.Columns = rows;
                    Board.Rows = rows;
                }
                else
                {
                    throw new Exception("Number should be more or equal to 3 and less or equal to 20");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Nrows.Text = string.Empty;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserButton_Checked(object sender, RoutedEventArgs e)
        {
            UserVsBotGameplay.UserVsBot = false;
            UpdateBoard.Update();
        }

        private void BotButton_Checked(object sender, RoutedEventArgs e)
        {
            UserVsBotGameplay.UserVsBot = true;
            UpdateBoard.Update();
        }
    }
}
