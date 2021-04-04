using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Tic_Tac_Toe.Refresheres;

namespace Tic_Tac_Toe.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public List<RadioButton> difficultyRadioButtons;
        public SettingsPage()
        {
            InitializeComponent();
            difficultyRadioButtons = new List<RadioButton>() { EasyButton, MediumButton, ImpossibleButton };
            if (UserVsBotGameplay.UserVsBot)
            {
                BotButton.IsChecked = true;
                difficultyRadioButtons.ElementAt(UserVsBotGameplay.Difficulty).IsChecked = true;
                foreach (var radioButton in difficultyRadioButtons)
                {
                    radioButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                UserButton.IsChecked = true;
                foreach (var radioButton in difficultyRadioButtons)
                {
                    radioButton.Visibility = Visibility.Hidden;
                }
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
                NavigationService.Navigate(new Uri("/Pages/BoardPage.xaml", UriKind.Relative));
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
            foreach(var radioButton in difficultyRadioButtons)
            {
                radioButton.Visibility = Visibility.Hidden;
            }
            UserVsBotGameplay.UserVsBot = false;
            UpdateBoard.Update();
        }

        private void BotButton_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var radioButton in difficultyRadioButtons)
            {
                radioButton.Visibility = Visibility.Visible;
            }
            difficultyRadioButtons.ElementAt(UserVsBotGameplay.Difficulty).IsChecked = true;
            UserVsBotGameplay.UserVsBot = true;
            UpdateBoard.Update();
        }

        private void InternetButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void EasyButton_Checked(object sender, RoutedEventArgs e)
        {
            UserVsBotGameplay.Difficulty = 0;
        }

        private void MediumButton_Checked(object sender, RoutedEventArgs e)
        {
            UserVsBotGameplay.Difficulty = 1;
        }

        private void ImpossibleButton_Checked(object sender, RoutedEventArgs e)
        {
            UserVsBotGameplay.Difficulty = 2;
        }
    }
}
