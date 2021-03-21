using System.Windows;
using Tic_Tac_Toe.Pages;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new BoardPage();
        }

        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new BoardPage();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettingsPage();
        }
    }
}
